using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("bid")]
    public class Bid
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("bid_amount", TypeName = "decimal(16, 2)")]
        public decimal BidAmount { get; set; }

        [Required]
        [Column("bid_time", TypeName = "datetime")]
        public DateTime BidDate { get; set; }

        //Reference to table BidUser (One to Many)
        public ICollection<BidUser> BidUser { get; set; } = null!;

        //Reference to table BidAuction (One to Many)
        public ICollection<BidAuction> BidAuction { get; set; } = null!;
    }
}
