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
            Id = Guid.NewGuid();
        }
        // set user's unique identifier
        [Key]
        [MaxLength(11)]
        public Guid Id { get; set; }

        // set first name
        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }


        // set second name
        [MinLength(2, ErrorMessage = "Too short surname")]
        [MaxLength(30)]
        [Required]
        public string Surname { get; set; }

        // user's login
        [MinLength(8, ErrorMessage = "Login should be 6 to 10 symbols")]
        [MaxLength(12, ErrorMessage = "Login should be 6 to 10 symbols")]
        [Index(IsUnique = true)]
        [Required] 
        public string Login { get; set; }

        // user's password
        // Think about making it not obligatory
        [MinLength(8, ErrorMessage = "Password should be 8 to 12 symbols")]
        [MaxLength(12, ErrorMessage = "Password should be 8 to 12 symbols")]
        [Required]
        public string Password { get; set; }

        // user type
        // check for using Foreign Keys here
        [MaxLength(2)]
        [Required]
        public int Type { get; set; }

        // if content for adults is allowed
        [DefaultValue(true)]
        public bool AllowAdultContent { get; set; }
    }
}