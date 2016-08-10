using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class UserSchedule
    {

        public UserSchedule()
        {

        }

        // set Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //ToDo Rename to DueDate
        // date when schedule expires
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime DateDue { get; set; }

        // set user ID from Users table
        [Required]
        public virtual User User { get; set; }

        //ToDo Naming convention !!!! TvShows
        // set show ID from TVShow table
        [Required]
        public virtual ICollection<TVShow> TVShows { get; set; }
    }
}