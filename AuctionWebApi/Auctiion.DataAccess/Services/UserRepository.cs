using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Auction.Domain.AutherizationModels;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Auction.Domain.AutherizationModels.SreviceResponse;

namespace Auctiion.DataAccess.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IPersonRepository _personRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IContacTypeRepository _contacTypeRepository;
        private readonly IPersonContactRepository _personContactRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly DataContext _context;

        public UserRepository(UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration,
                              IPersonRepository personRepository,
                              IRegionRepository regionRepository,
                              IContacTypeRepository contacTypeRepository,
                              IPersonContactRepository personContactRepository,
                              ICustomerRepository customerRepository,
                              DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _personRepository = personRepository;
            _regionRepository = regionRepository;
            _contacTypeRepository = contacTypeRepository;
            _personContactRepository = personContactRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<SreviceResponse.LoginResponse> LoginAccount(LoginDto loginDto)
        {
            if (loginDto == null)
                return new LoginResponse(false, 400, null!, "Login container is empty");

            var getUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (getUser is null)
                return new LoginResponse(false, 404, null!, "User not found");

            bool checkUserPasswords = await _userManager.CheckPasswordAsync(getUser, loginDto.Password);
            if (!checkUserPasswords)
                return new LoginResponse(false, 400, null!, "Invalid email/password");

            var getUserRole = await _userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.Id, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSession);
            return new LoginResponse(true, 201, token!, "Login completed");
        }

        //Registration of account
        public async Task<SreviceResponse.GeneralResponse> RegisterAccount(RegisterDto registerDto)
        {
            if (registerDto is null) return new GeneralResponse(false, 400, null!, "Model is empty");
            var newUser = new IdentityUser()
            {
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                UserName = registerDto.Email,
            };
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, 409, null!, "User registered already");

            var createUser = await _userManager.CreateAsync(newUser!, registerDto.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, 422, null!, "The password must contain 8 symbols: letter A-z, a special character, numbers");

            //Creating and adding info to record to table Persons
            var person = new Person
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Region = _regionRepository.GetRegionIdByName(registerDto.Region),
                Settlement = registerDto.Settlement,
            };

            //Creating and adding info to record to table PersonContacts 
            var personContact = new PersonContact
            {
                ContactType = _contacTypeRepository.GetIdByNameOfContactType("Email"),
                Person = person,
                ContactValue = registerDto.Email,
            };

            //Creating and adding info to record to table Customers
            var customer = new Customer
            {
                Person = person,
                CountOfBids = 0,
                User = newUser,
            };

            //Saving changes to context
            await _personRepository.CreatePersonAsync(person);
            await _personContactRepository.CreatePersonContactAsync(personContact);
            await _customerRepository.CreateCustomerAsync(customer);

            //Assign Default Role : Admin to first registrar; rest is user
            var checkAdmin = await _roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await _userManager.AddToRoleAsync(newUser, "Admin");
                var response = await LoginAccount(new LoginDto
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                });
                return new GeneralResponse(true, 201, response.Token, "Account Created");
            }
            else
            {
                var checkUser = await _roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                await _userManager.AddToRoleAsync(newUser, "User");

                var response = await LoginAccount(new LoginDto
                {
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                });
                //Add general information about person
                return new GeneralResponse(true, 201, response.Token, "Account Created");
            }
        }

        public async Task<bool> IsRegistred(string email)
        {
            var isExists = await _context.Users.AnyAsync(u => u.Email == email);
            return isExists;
        }

        //Generate JWT token with the key from configuration
        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //If user the first who register - the role is admin
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            //Generating token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
