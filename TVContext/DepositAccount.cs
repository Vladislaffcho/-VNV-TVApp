using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class DepositAccount
    {
        public DepositAccount()
        {
            
        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //the balance of the account
        [Required]
        public double Balance { get; set; }

        //whether active or suspended account
        [Required]
        public bool Status { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment (up 100 symbols)")]
        public string Comment { get; set; }


        //Make linked entity as virtual for lazy loading workS
        public virtual User User { get; set; }

    }
}