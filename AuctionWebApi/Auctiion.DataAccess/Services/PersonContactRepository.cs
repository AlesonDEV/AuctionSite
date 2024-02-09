using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class PersonContactRepository : IPersonContactRepository
    {
        private readonly DataContext _context;

        public PersonContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePersonContactAsync(PersonContact personContact)
        {
            await _context.PersonContacts.AddAsync(personContact);
            return await SaveAsync();
        }

        //Method for creating, updating, deleting
        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return  saved > 0 ? true : false;
        }
    }
}
