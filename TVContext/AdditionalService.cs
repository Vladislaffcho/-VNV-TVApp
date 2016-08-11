using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TVContext
{
    public class AdditionalService : IdentificableEntity
    {

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
        public bool IsAgeLimit { get; set; }

        //info about table OrderService
        public virtual OrderService OrderService { get; set; }

    }
}