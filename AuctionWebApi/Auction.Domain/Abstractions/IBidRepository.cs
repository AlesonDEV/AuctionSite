using Auction.Domain.Dto;
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
        Task<ICollection<BidGetDto>> GetBidsByAuction(int auctionId);
        Task<Bid> GetBidById(int bidId);
        Task<bool> BidExist(int bidId);
        Task<bool> Save();
        Task<bool> BidCreate(Bid bid);
        Task<bool> BidDelete(Bid bid);
    }
}
