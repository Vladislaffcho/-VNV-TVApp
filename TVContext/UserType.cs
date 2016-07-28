﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVContext
{
    
    public class UserType
    {
        public UserType()
        {
            //this.Users = new List<User>();
        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //create unique field for type of users
        //[Index(IsUnique = true)]
        [MinLength(2, ErrorMessage = "Too short address")]
        [MaxLength(30)]
        [Required]
        public string TypeName { get; set; }

        //create field for type of access each position
        [MinLength(2, ErrorMessage = "Too short access description (must be 2-100 symbols)")]
        [MaxLength(300)]
        [Required]
        public string AccessToData { get; set; }

        //comment for different situations
        [MaxLength(100, ErrorMessage = "Too long comment (must be less than 100 symbols)")]
        public string Comment { get; set; }

        //list of users who have specified access
        //public virtual ICollection<User> Users { get; set; }
        
        
    }
}