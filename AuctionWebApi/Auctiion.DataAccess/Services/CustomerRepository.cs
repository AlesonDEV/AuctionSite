using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
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

namespace Auctiion.DataAccess.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> GetUserIdByEmail(string email)
        {
            var user = await _context.Users
                                   .Where(e => e.Email == email)
                                   .FirstOrDefaultAsync();

            return user;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var user = await GetUserIdByEmail(email);
            var customer = await _context.Customers
                                      .Where(u => u.UserId == user.Id)
                                      .FirstOrDefaultAsync();
            return customer;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
