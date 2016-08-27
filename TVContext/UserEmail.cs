using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class UserEmail : CommentedEntity
    {
        public UserEmail()
        {
            
        }

        // set unique email address
        [MinLength(5, ErrorMessage = "Too short email (must be 5-50)")]
        [MaxLength(50)]
        [Required]
        [Index(IsUnique = true)]
        public string EmailName { get; set; }

        // set email owner ID from Users table
        [Required]
        public virtual User User { get; set; }

        // set Connect Type
        [Required]
        public virtual TypeConnect TypeConnect { get; set; }
    }
}