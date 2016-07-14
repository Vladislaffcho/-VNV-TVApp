using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class Email
    {
        public Email()
        {
            Id = Guid.NewGuid();
        }
        // set unique identifier
        [Key]
        //[MaxLength(11)]
        public Guid Id { get; set; }

        // set email owner ID
        //need to use Foreign Key
        //[MaxLength(11)]
        [Required]
        public int IdUser { get; set; }

        // set unique email address
        [MinLength(5, ErrorMessage = "Too short email")]
        [MaxLength(50)]
        [Required]
        [Index(IsUnique = true)]
        public string EmailName { get; set; }

        // comment in case it is required
        [MaxLength(100, ErrorMessage = "Too long comment")]
        [DefaultValue(null)]
        public string Comment { get; set; }

        //set address type
        //[MaxLength(11)]
        [Required]
        public int TypeAddress { get; set; }
    }
}