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
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePersonAsync(Person person)
        {
            await _context.AddAsync(person);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved =  await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
