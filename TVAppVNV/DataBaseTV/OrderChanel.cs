using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class OrderChanel
    {
        public OrderChanel()
        {

        }
        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        private int ChannelId { get; set; }


        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual Channel Chanel { get; set; }

    }
}