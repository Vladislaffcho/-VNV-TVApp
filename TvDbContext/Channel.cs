using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvDbContext
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
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}