using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    public class Payment : IdentificableEntity
    {
        public Payment()
        {
            
        }

        //Payment date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        //Payment sum
        [Required]
        public double Summ { get; set; }

        //Make linked entity as virtual for lazy loading work
        [Required]
        public virtual Order Order { get; set; }

    }
}