using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    
    public class UserType : CommentedEntity
    {

        //create unique field for type of users
        //[Index(IsUnique = true)]
        [MinLength(2, ErrorMessage = "Too short address")]
        [MaxLength(30)]
        [Required]
        public string TypeName { get; set; }

        //create field for type of access each position
        [MinLength(2, ErrorMessage = "Too short access description (must be 2-100 symbols)")]
        [MaxLength(300)]
        [Required]
        public string AccessToData { get; set; }


        //list of users who have specified access
        //public virtual ICollection<User> Users { get; set; }
        
    }
}