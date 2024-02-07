using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("item_details")]
    public class ItemDetails
    {
        [Key, ForeignKey(nameof(AuctionDetails))]
        [Column("auction_details_id")]
        public int AuctionDetailsId { get; set; }

        [Required]
        [Column("condition_id", TypeName = "varchar255")]
        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }

        //Reference to table Condition (Many to one)
        public Condition Condition { get; set; } = null!;

        //Reference to table AuctionDetails (One to one)
        public AuctionDetails AuctionDetails { get; set; } = null!;

        //Reference to table Photo (One to Many)
        public ICollection<Photo> Photos { get; set; } = null!;
    }
}
