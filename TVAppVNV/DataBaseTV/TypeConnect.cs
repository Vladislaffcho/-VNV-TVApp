using System;
using System.ComponentModel.DataAnnotations;

namespace TVAppVNV.DataBaseTV
{
    public class TypeConnect
    {
        public TypeConnect()
        {
            Id = Guid.NewGuid();
        }

        // set unique identifier
        [Key]
        //[MaxLength(11)]
        public Guid Id { get; set; }

        // set contact type name
        [MinLength(3, ErrorMessage = "Too short contact type name")]
        [MaxLength(30)]
        [Required]
        public string NameType { get; set; }
    }
}