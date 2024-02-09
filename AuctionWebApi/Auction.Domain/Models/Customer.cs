using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    public class Customer 
    {
        [Key, ForeignKey(nameof(Person))]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Column("count_of_bids")]
        public int CountOfBids { get; set; }

        [Column("user_id")]
        [ForeignKey(nameof(IdentityUser))]
        public string? UserId { get; set; } = null!;

        //Reference to table Users (One to One)
        public IdentityUser User { get; set; } = null!;

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
