using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class Channel : CommentedEntity
    {
        public Channel()
        {
            TvShows = new List<TvShow>();
            OrderChannel = new List<OrderChannel>();
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

        //original id of channel which gets from xml incoming data file
        [Required]
        //[ForeignKey("TvShow")]
        public int OriginalId { get; set; }

        //info about orders
        public virtual ICollection<OrderChannel> OrderChannel { get; set; }

        public virtual ICollection<TvShow> TvShows { get; set; }

    }
}