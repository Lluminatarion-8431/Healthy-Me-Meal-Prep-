using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Goal")]
        public string goal { get; set; }

        [Display(Name = "Age")]
        public double age { get; set; }

        [Display(Name = "Height")]
        public double height { get; set; }

        [Display(Name = "Weight")]
        public double weight { get; set; }

        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        


        

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
