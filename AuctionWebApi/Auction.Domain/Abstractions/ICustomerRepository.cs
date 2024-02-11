using Auction.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomerAsync(Customer customer);

        Task<Customer> GetCustomerByEmail(string email);

        Task<IdentityUser> GetUserIdByEmail(string email);

        Task<bool> SaveAsync();
    }
}
