using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    public class Status
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; } = null!;

        //Reference to table Auction (One to Many)
        public ICollection<Auction> Auctions { get; set; } = null!;
    }
}
