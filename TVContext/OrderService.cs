using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVContext
{
    public class OrderService : IdentificableEntity
    {
        public OrderService()
        {
            AdditionalServices = new List<AdditionalService>();
        }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }


    }
}