using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models
{
    [Table("Person_Contact")]
    public class PersonContact
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Person))]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey(nameof(ContactType))]
        [Column("contact_type_id")]
        public int ContactTypeId { get; set; }

        [Required]
        [Column("contact_value", TypeName = "varchar(100)")]
        public string ContactValue { get; set; } = null!;

        //Reference to table Person (Many to one)
        public Person Person { get; set; } = null!;

        //Reference to table ContactType (Many to one)
        public ContactType ContactType { get; set; } = null!;
    }
}
