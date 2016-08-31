using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TvContext
{
    public class OrderService : IdentificableEntity
    {
        public OrderService()
        {
            
        }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual AdditionalService AdditionalService { get; set; }
    }
}