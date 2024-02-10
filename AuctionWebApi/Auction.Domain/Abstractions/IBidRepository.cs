using Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Abstractions
{
    public interface IBidRepository
    {
        ICollection<Bid> GetBidsByAuction(int auctionId);
        ICollection<Bid> GetBidsByUser(int userId);
        Bid GetBidById(int id);
        bool Save();
        bool BidCreate(Bid bid);
        bool BidUpdate(Bid bid);
        bool BidDelete(Bid bid);
    }
}
