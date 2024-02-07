using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column("last_name", TypeName = "varchar")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column("region_id")]
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        [Required]
        [Column("settlement", TypeName = "varchar")]
        public string Settlement { get; set; } = null!;

        [Required]
        [Column("hashed_password", TypeName = "varchar")]
        public string HashedPassword { get; set; } = null!;

        [Column("hashed_reserved_password", TypeName = "varchar")]
        public string HashedReservedPassword { get; set; } = null!;

        //Reference to table Region (Many to one)
        public Region Region { get; set; } = null!;

        //Reference to table PersonContact (One to many)
        public ICollection<PersonContact> PersonContact { get; set; } = null!;
    }
}
