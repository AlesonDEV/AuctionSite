using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    //Represent relationship between bids and auctions (Many to many)
    [Table("bid_auction")]
    public class BidAuction
    {
        [Column("bid_id")]
        public int BidId { get; set; }

        [Column("auction_id")]
        public int AuctionId { get; set;}

        //Reference to table Bid (Many to one)
        public Bid Bid { get; set; } = null!;

        //Reference to table Auction (Many to one)
        public Auction Auction { get; set; } = null!;
    }
}
