using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace TVAppVNV.DataBaseTV
{
    public class UserAddress
    {
        public UserAddress()
        {
            Id = Guid.NewGuid();
        }
        //Mark this field as primary key
        [Key]
        [MaxLength(11)]
        public Guid Id { get; set; }

        //create unique field of user address ???
        //[Index(IsUnique = true)]
        [MinLength(10, ErrorMessage = "Too short address")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        //create field for type address(home, work, dacha....)
        [MaxLength(11)]
        [Required]
        public int TypeAddress { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment")]
        public string Comment { get; set; }

        //Id of user, who has this address
        [MaxLength(11)]
        [Required]
        public int IdUser { get; set; }

        //Make linked entity as virtual for lazy loading work
        //[Required]
        //public virtual Users Users { get; set; }

        //[Required]
        //public virtual TypeConnect TypeConnect { get; set; }
        
            
        


    }
}