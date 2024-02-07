using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    //Represent relationship between auctions and users (Many to many)
    [Table("auction_user")]
    public class AuctionUser
    {
        [Column("auction_id")]
        public int AuctionId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        //Reference to table Auction (Many to one)
        public Auction Auction { get; set; } = null!;

        //Reference to table User (Many to one)
        public User User { get; set; } = null!;
    }
}
