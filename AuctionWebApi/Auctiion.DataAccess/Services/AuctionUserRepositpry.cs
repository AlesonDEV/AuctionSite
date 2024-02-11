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
    public class AuctionUserRepositpry : IAuctionUserRepository
    {
        private readonly DataContext _context;

        public AuctionUserRepositpry(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAuctionUser(AuctionUser auctionUser)
        {
            await _context.AddAsync(auctionUser);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
