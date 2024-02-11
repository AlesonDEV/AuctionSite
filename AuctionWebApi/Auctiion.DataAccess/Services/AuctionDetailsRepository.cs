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
    public class AuctionDetailsRepository : IAuctionDetailsRepository
    {
        private readonly DataContext _context;

        public AuctionDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAuctionDetails(AuctionDetails auctionDetails)
        {
            await _context.AuctionDetails.AddAsync(auctionDetails);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
