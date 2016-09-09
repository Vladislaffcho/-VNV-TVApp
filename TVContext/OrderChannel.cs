using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class OrderChannel : IdentificableEntity
    {

        public OrderChannel()
        {
            
        }

        //link to Channel entity(FK)
        [Required]
        public virtual Channel Channel { get; set; }

        //link to current user who are choosing media and make order
        [Required]
        public virtual User User { get; set; }

        //Make linked entity as virtual for lazy loading work
        //[Required]
        public virtual Order Order { get; set; }

        
    }
}