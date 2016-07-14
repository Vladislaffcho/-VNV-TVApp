using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class UserEmail
    {
        // set Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        // set email owner ID from Users table
        [Required]
        public virtual User User { get; set; }

        // set Connect Type
        [Required]
        public virtual TypeConnect TypeConnect { get; set; }
    }
}