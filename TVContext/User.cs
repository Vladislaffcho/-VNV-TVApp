﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TvContext
{
    public class User : IdentificableEntity
    {

        public User()
        {
            //Add all collections
            UserAddresses = new List<UserAddress>();
            UserPhones = new List<UserPhone>();
            UserEmails = new List<UserEmail>();
            Orders = new List<Order>();
            UserSchedules = new List<UserSchedule>();
        } 

        // set user's unique identifier
       

        // set first name
        [MinLength(1, ErrorMessage = "Too short name (must be 1-30)")]
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }


        // set second name
        [MinLength(1, ErrorMessage = "Too short surname (must be 1-30)")]
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        // user's login
        [MinLength(2, ErrorMessage = "Login should be 2 to 20 symbols")]
        [MaxLength(20, ErrorMessage = "Login should be 2 to 20 symbols")]
        //[Index(IsUnique = true)]
        [Required] 
        public string Login { get; set; }

        // user's password
        // Think about making it not obligatory
        [MinLength(0, ErrorMessage = "Password should be 0 to 20 symbols")]
        [MaxLength(200, ErrorMessage = "Password should be 0 to 200 symbols")]
        [Required]
        public string Password { get; set; }

        // if content for adults is allowed
        [DefaultValue(false)]
        public bool IsAllowAdultContent { get; set; }

        //set type of a user from UserType table

        [Required]
        public virtual UserType UserType { get; set; }

        [DefaultValue(true)]
        public bool IsActiveStatus { get; set; }


        //FK for UserAddress table
        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        //Phones list of user
        public virtual ICollection<UserPhone> UserPhones { get; set; }

        //Emails list of user
        public virtual ICollection<UserEmail> UserEmails { get; set; }

        //[Required]
        //info about user's account
        //public virtual DepositAccount DepositAccount { get; set; }

        //orders list of user
        public virtual ICollection<Order> Orders { get; set; }

        //info about user TvShow Schedule
        public virtual ICollection<UserSchedule> UserSchedules { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + " " + LastName + " " + UserType + Environment.NewLine;
        //}
    }
}