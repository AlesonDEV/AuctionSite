using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("file_path", TypeName = "varchar(255)")]
        public string FilePath { get; set; } = null!;

        [Column("binary_data", TypeName = "varchar(500)")]
        public string BinaryData { get; set; } = null!;

        [Required]
        [Column("item_id")]
        [ForeignKey(nameof(ItemDetails))]
        public int ItemId { get; set; }

        //Reference to table ItemDetail (Many to one)
        public ItemDetails ItemDetails { get; set; } = null!;
    }
}
