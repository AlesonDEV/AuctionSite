using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    public class Region
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = null!;

        //Reference to table Person (One to Many)
        public ICollection<Person> Persons { get; set; } = null!;
    }
}
