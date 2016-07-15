using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class OrderService
    {
        public OrderService()
        {

        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OredrId { get; set; }

        [Required]
        public int AdditionalServiceId { get; set; }


        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual AdditionalService AdditionalService { get; set; }


    }
}