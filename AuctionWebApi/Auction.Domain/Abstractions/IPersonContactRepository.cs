using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IPersonContactRepository
    {
        Task<bool> CreatePersonContactAsync(PersonContact personContact);
        Task<bool> SaveAsync();
    }
}
