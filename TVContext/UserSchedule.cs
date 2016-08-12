using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class UserSchedule : IdentificableEntity
    {

        public UserSchedule()
        {
            TvShows = new List<TvShow>();
        }

        //ToDo Rename to DueDate
        // date when schedule expires
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime DueDate { get; set; }

        // set user ID from Users table
        [Required]
        public virtual User User { get; set; }

        //ToDo Naming convention !!!! TvShows
        // set show ID from TvShow table
        [Required]
        public virtual ICollection<TvShow> TvShows { get; set; }
    }
}