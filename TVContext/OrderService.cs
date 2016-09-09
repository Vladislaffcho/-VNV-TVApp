using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TvContext
{
    public class OrderService : IdentificableEntity
    {
        public OrderService()
        {
            
        }

        //link to current user who are choosing media and make order
        [Required]
        public virtual User User { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual AdditionalService AdditionalService { get; set; }

        //Make linked entity as virtual for lazy loading work
        public virtual Order Order { get; set; }

        
    }
}