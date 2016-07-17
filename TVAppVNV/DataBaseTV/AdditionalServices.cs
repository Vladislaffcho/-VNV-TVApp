using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVAppVNV.DataBaseTV
{
    class AdditionalServices
    {
        public AdditionalServices()
        {
            
        }
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public char name { get; set; } 

        [Required]
        public double price { get; set; }
        
        // if ageLimit - OK - true
        [Required]
        [DefaultValue(false)]
        public bool ageLimit { get;set }
         

    }
}
