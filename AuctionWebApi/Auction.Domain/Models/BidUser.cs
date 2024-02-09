using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    //Represent relationship between bids and users (Many to many)
    [Table("Bid_User")]
    public class BidUser
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("bid_id")]
        public int BidId { get; set; }

        //Reference to table User (Many to one)
        public Customer Customer { get; set; } = null!;

        //Reference to table Bid (Many to one)
        public Bid Bid { get; set; } = null!;
    }
}
