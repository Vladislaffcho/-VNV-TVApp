using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class Order : IdentificableEntity
    {
        public Order()
        {
            //OrderChannels = new List<OrderChannel>();
            //OrderServices = new List<OrderService>();
        }

        //Oreder date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateOrder { get; set; }

        //Oreder's begin date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FromDate { get; set; }

        //Oreder's finish date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DueDate { get; set; }

        //order price per week
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double TotalPrice { get; set; }

        //true - paid, false - not paid
        [Required]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
        
        //order finished - true, not finished - false
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //FK for OrderService table
        [Required]
        public User User { get; set; }

        //info about all ordered servisec and channels
        public ICollection<OrderChannel> OrderChannels { get; set; }

        public ICollection<OrderService> OrderServices { get; set; }

    }
}