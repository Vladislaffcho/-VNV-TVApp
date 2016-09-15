using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class UserSchedule : IdentificableEntity
    {

        public UserSchedule()
        {
            //TvShows = new List<TvShow>();
        }

        // date when schedule expires
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        //[ForeignKey("TvShow")]
        public virtual TvShow TvShow { get; set; }

        // set user ID from Users table
        [Required]
        public virtual User User { get; set; }

     
        // set show ID from TvShow table
        //[Required]
        //public virtual ICollection<TvShow> TvShows { get; set; }
    }
}