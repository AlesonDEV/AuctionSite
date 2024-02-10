using Auctiion.DataAccess.Data;
using Auction.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctiion.DataAccess.Services
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DataContext _context;

        public AuctionRepository(DataContext context)
        {
            _context = context;
        }
        
        //Get preview information about auction
        public async Task<ICollection<Auction.Domain.Models.Auction>> GetPreviewInformationOfAuctions(int countOfAuctions)
        {
            var auctions = await _context.Auctions.Take(countOfAuctions).ToListAsync();
            return (ICollection<Auction.Domain.Models.Auction>)auctions;
        }
    }
}
