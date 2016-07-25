using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace TVContext
{
    public class Channel
    {
        public Channel()
        {

        }

        //primary key
        //autoincrement
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int OriginalId { get; set; }

        //channel name
        [Required]
        public string Name { get; set; }

        //channel price per week
        [Required]
        public double Price { get; set; }
     
        // if ageLimit 18+ - true
        [Required]
        [DefaultValue(false)]
        public bool AgeLimit { get; set; }

        //description of channel
        [MaxLength(500)]
        public string Description { get; set; }

        //info about orders
        public virtual OrderChannel OrderChannel { get; set; }

        public virtual ICollection<TVShow> TvShows { get; set; }

    }
}