using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class UserPhone : CommentedEntity
    {
        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
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