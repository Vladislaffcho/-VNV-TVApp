using System.ComponentModel.DataAnnotations;

namespace TVContext
{
    public class CommentedEntity : IdentificableEntity
    {
        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment (must be less than 100 symbols)")]
        public string Comment { get; set; }
    }
}