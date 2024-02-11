using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Auction.Domain.Dto;
using Auction.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class BidRepository : IBidRepository
    {
        private readonly DataContext _context;

        public BidRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<BidGetDto>> GetBidsByAuction(int auctionId)
        {
            var bids = await _context.BidAuctions.Where(ba => ba.AuctionId == auctionId)
                                                .Join(_context.Bids,
                                                ba => ba.BidId,
                                                b => b.Id,
                                                (ba, b) => new 
                                                {
                                                    ba.BidId,
                                                    auctionId,
                                                    b.BidAmount,
                                                })
                                                .Join(_context.BidUsers,
                                                b => b.BidId,
                                                bu => bu.BidId,
                                                (b, bu) => new BidGetDto
                                                {
                                                    BidId = b.BidId,
                                                    AuctionId = b.auctionId,
                                                    BidAmount = b.BidAmount,
                                                    UserId = bu.UserId,
                                                })
                                                .ToListAsync();

            return bids;
        }

        public ICollection<Bid> GetBidsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> BidCreate(Bid bid)
        {
            await _context.AddAsync(bid);
            return await Save();
        }

        public async Task<bool> BidExist(int bidId)
        {
            return await _context.Bids.Where(p => p.Id == bidId).AsNoTracking().FirstOrDefaultAsync() != null ? true : false;
        }

        public async Task<bool> BidDelete(Bid bid)
        {
            _context.Remove(bid);
            return await Save();
        }

        public async Task<Bid> GetBidById(int bidId)
        {
            return await _context.Bids.Where(a => a.Id == bidId).FirstOrDefaultAsync();
        }

    }
}
