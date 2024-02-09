using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IPersonRepository
    {
        Task<bool> CreatePersonAsync(Person person);
        Task<bool> SaveAsync();
    }
}
