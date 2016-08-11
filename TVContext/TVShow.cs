using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class TvShow : CommentedEntity
    {
        public TvShow()
        {
            UserSchedules = new List<UserSchedule>();
        }

        // set show name
        [MinLength(2, ErrorMessage = "Too short name (must be 2-255)")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        // date of a show broadcasting
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }

        // false if a show does not have age limitations
        [DefaultValue(false)]
        public bool IsAgeLimit { get; set; }
       
        // link with table Channel
        [Required]
        public virtual Channel Channel { get; set; }

        //info about all UserShedule which ordered this show
        public virtual ICollection<UserSchedule> UserSchedules { get; set; }
    }
}