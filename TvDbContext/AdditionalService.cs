using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvDbContext
{
    public class AdditionalService
    {
        public AdditionalService()
        {

        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //this service name
        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        //service price per week
        [Required]
        public double Price { get; set; }

        //true - content for everyone, false - only 18+
        [Required]
        [DefaultValue(true)]
        public bool AgeLimit { get; set; }

        //info about table OrderService
        public virtual OrderService OrderService { get; set; }



    }
}