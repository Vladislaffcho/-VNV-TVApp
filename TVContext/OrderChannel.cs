using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class OrderChannel : IdentificableEntity
    {
        public OrderChannel()
        {
            //Channels = new List<Channel>();
        }

        [Required]
        public virtual Channel Channel { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        //public virtual ICollection<Channel> Channels { get; set; }

    }
}