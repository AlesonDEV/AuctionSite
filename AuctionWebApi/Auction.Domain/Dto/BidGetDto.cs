using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dto
{
    public class BidGetDto
    {
        public int BidId { get; set; }

        public int UserId { get; set; }

        public int AuctionId { get; set; }

        public decimal BidAmount { get; set; }
    }
}
