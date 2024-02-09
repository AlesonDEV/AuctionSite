using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    public class Person
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar(255)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column("last_name", TypeName = "varchar(255)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column("region_id")]
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        [Required]
        [Column("settlement", TypeName = "varchar(255)")]
        public string Settlement { get; set; } = null!;

        //Reference to table Region (Many to one)
        public Region Region { get; set; } = null!;

        //Reference to table PersonContact (One to many)
        public ICollection<PersonContact> PersonContact { get; set; } = null!;
    }
}
