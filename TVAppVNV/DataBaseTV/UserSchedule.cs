using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class UserSchedule
    {
        public UserSchedule()
        {
            Id = Guid.NewGuid();
        }
        // set unique identifier
        [Key]
        [MaxLength(11)]
        public Guid Id { get; set; }

        // set user ID for a particular user
        //need to use Foreign Key
        [MaxLength(11)]
        [Required]
        public int IdUser { get; set; }

        // set show ID
        //need to use Foreign Key
        [MaxLength(11)]
        [Required]
        public int IdShow { get; set; }
        
        // time of a show broadcasting
        [Column(TypeName = "datetime2")]
        public DateTime AirTime { get; set; }
    }
}