using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("user")]
    public class User
    {
        [Key, ForeignKey(nameof(Person))]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Required]
        [Column("card_number", TypeName = "varchar(25)")]
        public string CardNumber { get; set; } = null!;

        [Column("count_of_bids")]
        public int CountOfBids { get; set; }

        //Reference to table Person (One to one)
        public Person Person { get; set; } = null!;

        //Reference to table UserBid (One to Many)
        public ICollection<BidUser> BidUser { get; set; } = null!;
        
        //Reference to table AuctionUse (One to Many)
        public ICollection<AuctionUser> AuctionUser { get; set; } = null!;

        //Reference to table AuctionDetail (One to Many)
        public ICollection<AuctionDetails> AuctionDetails { get; set; } = null!;
    }
}
