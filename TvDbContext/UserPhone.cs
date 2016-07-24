using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvDbContext
{
    public class UserPhone
    {
        public UserPhone()
        {
            
        }
        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //create unique field of user phone
        [Index(IsUnique = true)]
        [Required]
        public int Number { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment")]
        public string Comment { get; set; }
        
        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual TypeConnect TypeConnect { get; set; }

    }
}