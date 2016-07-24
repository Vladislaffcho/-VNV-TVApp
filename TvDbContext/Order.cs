using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvDbContext
{
    public class Order
    {
        public Order()
        {

        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Oreder date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateOrder { get; set; }

        //Oreder's begin date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateFrom { get; set; }

        //Oreder's finish date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateDue { get; set; }

        //order price per week
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double TotalPrice { get; set; }

        //true - paid, false - not paid
        [Required]
        [DefaultValue(false)]
        public bool Paid { get; set; }
        
        //order finished - true, not finished - false
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //FK for OrderService table
        [Required]
        public virtual User User { get; set; }

        //info about this payment
        public virtual Payment Payment { get; set; }

        //info about all ordered servisec and channels
        public virtual ICollection<OrderChannel> OrderChannels { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }

    }
}