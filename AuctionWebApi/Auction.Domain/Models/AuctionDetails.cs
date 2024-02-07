using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("auction_details")]
    public class AuctionDetails
    {
        [Key, ForeignKey(nameof(Auction))]
        [Column("auction_id")]
        public int AuctionId { get; set; }

        [Column("current_buyer_id")]
        [ForeignKey(nameof(User))]
        public int CurrentBuyerId { get; set; }

        [Required]
        [MinLength(70)]
        [Column("description", TypeName = "varchar")]
        public string Description { get; set; } = null!;

        [Required]
        [Column("start_time", TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("end_time", TypeName = "datatime")]
        public DateTime EndTime { get; set; }

        [Required]
        [Column("starting_price", TypeName = "decimal(16, 2)")]
        public decimal StartingPrice { get; set; }

        [Required]
        [Column("current_price", TypeName = "decimal(16, 2)")]
        public decimal CurrentPrice { get; set; }

        //Reference to table User (Many to one)
        public User User { get; set; } = null!;

        //Reference to table Auction (One to one)
        public Auction Auction { get; set; } = null!;
    }
}
