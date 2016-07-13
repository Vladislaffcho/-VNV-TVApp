using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class TVShow
    {
        public TVShow()
        {
            Id = Guid.NewGuid();
        }
        // set unique identifier
        [Key]
        [MaxLength(11)]
        public Guid Id { get; set; }

        // set channel ID for a particular show
        //need to use Foreign Key
        [MaxLength(11)]
        [Required]
        public int IdChannel { get; set; }

        // true if show is currently in air
        [DefaultValue(true)]
        public bool Status { get; set; }

        // time of a show broadcasting
        // think about removing one property from here or Schedule class
        [Column(TypeName = "datetime2")]
        public DateTime AirTime { get; set; }

        // false if a show does not have age limitations
        [DefaultValue(false)]
        public bool AgeLimit { get; set; }

        //[NotMapped]
        //public string Gogo { get; set; }
    }
}