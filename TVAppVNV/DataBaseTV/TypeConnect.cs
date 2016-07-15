using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
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
        [MinLength(3, ErrorMessage = "Too short contact type name")]
        [MaxLength(30)]
        [Required]
        public string NameType { get; set; }

    }

}