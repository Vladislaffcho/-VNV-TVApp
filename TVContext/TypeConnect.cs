using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class TypeConnect
    {
        public TypeConnect()
        {

        }
        // set Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // set contact type name
        [MinLength(3, ErrorMessage = "Too short contact type name (must be 3-30)")]
        [MaxLength(30)]
        [Required]
        public string NameType { get; set; }

        //lists different connecting ways
        public virtual ICollection<UserPhone> UserPhones { get; set; }

        public virtual ICollection<UserAddress> UserAddresses{ get; set; }

        public virtual ICollection<UserEmail> UserEmails { get; set; }

    }

}