using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class UserAddress : CommentedEntity
    {
        public UserAddress()
        {
            
        }

        //create unique field of user address ???
        [Index(IsUnique = true)]
        [MinLength(5, ErrorMessage = "Too short address (must be 5-100)")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual TypeConnect TypeConnect { get; set; }
        
    }
}