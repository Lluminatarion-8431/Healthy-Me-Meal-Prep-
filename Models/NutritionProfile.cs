using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class NutritionProfile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Food Allergies")]
        public string foodAllegies { get; set; }

        [Display(Name = "Nutritional Goal")]
        public string goal { get; set; }

        [Display(Name = "Fitness goal start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Fitness goal end date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Starting Weight")]
        public double startingWeight { get; set; }

        [Display(Name = "Ending Weight")]
        public double endingWeight { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer customer { get; set; }
    }
}
