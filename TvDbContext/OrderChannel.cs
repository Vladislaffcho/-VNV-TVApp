using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvDbContext
{
    public class OrderChannel
    {
        public OrderChannel()
        {

        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual Channel Channel { get; set; }

    }
}