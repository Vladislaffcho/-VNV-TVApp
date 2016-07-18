using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class UserType
    {
        public UserType()
        {
            //Id++;
        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //create unique field for type of users
        [Index(IsUnique = true)]
        [MinLength(2, ErrorMessage = "Too short address")]
        [MaxLength(30)]
        [Required]
        public string TypeName { get; set; }

        //create field for type of access each position
        [MinLength(2, ErrorMessage = "Too short access description")]
        [MaxLength(30)]
        [Required]
        public string AccessToData { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment")]
        public string Comment { get; set; }

        
    }
}