using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class UserAddress
    {
        public UserAddress()
        {
             
        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //create unique field of user address ???
        [Index(IsUnique = true)]
        [MinLength(10, ErrorMessage = "Too short address")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        //create field for type address(home, work, dacha....)
        [Required]
        public int TypeConnectId { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment")]
        public string Comment { get; set; }

        //Id of user, who has this address
        [Required]
        public int UserId { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual TypeConnect TypeConnect { get; set; }

        

    }
}