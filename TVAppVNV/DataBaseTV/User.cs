using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class User
    {

        public User()
        {
            Id++;
        } 
        // set user's unique identifier
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // set first name
        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }


        // set second name
        [MinLength(2, ErrorMessage = "Too short surname")]
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        // user's login
        [MinLength(6, ErrorMessage = "Login should be 6 to 12 symbols")]
        [MaxLength(12, ErrorMessage = "Login should be 6 to 12 symbols")]
        [Index(IsUnique = true)]
        [Required] 
        public string Login { get; set; }

        // user's password
        // Think about making it not obligatory
        [MinLength(6, ErrorMessage = "Password should be 6 to 12 symbols")]
        [MaxLength(12, ErrorMessage = "Password should be 6 to 12 symbols")]
        [Required]
        public string Password { get; set; }
        
        // if content for adults is allowed
        [DefaultValue(true)]
        public bool AllowAdultContent { get; set; }

        [Required] 
        public int UserTypeId { get; set; }

        // set type of a user from UserType table
        [Required]
        public virtual UserType UserType { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + UserType + Environment.NewLine;
        }
    }
}