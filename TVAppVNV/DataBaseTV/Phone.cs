using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class Phone
    {
        public Phone()
        {
            
        }
        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //Id of user, who has this phone
        [MaxLength(11)]
        [Required]
        public int UserId { get; set; }
        
        //create unique field of user phone
        [Index(IsUnique = true)]
        [MaxLength(11)]
        [Required]
        public int Number { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment")]
        public string Comment { get; set; }
        
        //create field for type phone(home, work, for advertise....)
        [MaxLength(11)]
        [Required]
        public int TypePhone { get; set; }
        
        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual TypeConnect TypeConnect { get; set; }

    }
}