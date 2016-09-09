using System.ComponentModel.DataAnnotations;

namespace TvContext
{
    public class Account : CommentedEntity
    {
        //public Account()
        //{
            
        //}

        //the balance of the account
        [Required]
        public double Balance { get; set; }

        //whether active or suspended account
        [Required]
        public bool IsActiveStatus { get; set; }

        //Make linked entity as virtual for lazy loading workS
        public User User { get; set; }

    }
}