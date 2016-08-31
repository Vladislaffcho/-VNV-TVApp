using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class UserPhone : CommentedEntity
    {
        //create unique field of user phone
        [Index(IsUnique = true)]
        [Required]
        public int Number { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual TypeConnect TypeConnect { get; set; }

    }
}