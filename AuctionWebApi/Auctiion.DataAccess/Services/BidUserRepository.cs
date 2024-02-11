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
    public class BidUserRepository : IBidUserRepository
    {
        private readonly DataContext _context;

        public BidUserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> BidUserCreate(BidUser bibUser)
        {
            await _context.AddAsync(bibUser);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
