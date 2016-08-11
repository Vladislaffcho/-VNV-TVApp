using System.ComponentModel.DataAnnotations;

namespace TVContext
{
    public class CommentedEntity : IdentificableEntity
    {
        //comment for different situations
        [MaxLength(500, ErrorMessage = "Too long comment (must be less than 500 symbols)")]
        public string Comment { get; set; }
    }
}