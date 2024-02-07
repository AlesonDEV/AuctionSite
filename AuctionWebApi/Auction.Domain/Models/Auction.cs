using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("auction")]
    public class Auction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title", TypeName = "varchar")]
        public string Title { get; set; } = null!;

        [Required]
        [Column("categoty_id")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        [Column("status_id")]
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        //Reference to table Category (Many to one)
        public Category Category { get; set; } = null!;

        //Reference to table Status (Many to one)
        public Status Status { get; set; } = null!;

        //Reference to table AuctionUser (One to Many)
        public ICollection<AuctionUser> AuctionUser { get; set; } = null!;

        //Reference to table BidAuction (One to Many)
        public ICollection<BidAuction> BidAuction { get; set; } = null!;
    }
}
