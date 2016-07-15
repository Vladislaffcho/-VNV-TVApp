using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVAppVNV.DataBaseTV
{
    public class Channel
    {
        public Channel 
        {
            Id = Guid.NewGuid();
        }
    //set unique idintifier
    [Key]
    [MaxLength 11]

        public Guid Id = {get; set;};

        public string name { get; set; }
        public float price { get; set; }
    }

}
