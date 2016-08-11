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
            Channels = new List<Channel>();
        }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual ICollection<Channel> Channels { get; set; }

    }
}