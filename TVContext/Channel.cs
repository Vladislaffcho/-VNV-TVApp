using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TVContext
{
    public class Channel : CommentedEntity
    {
        public Channel()
        {
            TvShows = new List<TvShow>();
        }

        //channel name
        [Required]
        public string Name { get; set; }

        //channel price per week
        [Required]
        public double Price { get; set; }

        //ToDo Naming convention !!!! IsAgeLimit
        // if ageLimit 18+ - true
        [Required]
        [DefaultValue(false)]
        public bool IsAgeLimit { get; set; }

        //info about orders
        public virtual OrderChannel OrderChannel { get; set; }

        public virtual ICollection<TvShow> TvShows { get; set; }

    }
}