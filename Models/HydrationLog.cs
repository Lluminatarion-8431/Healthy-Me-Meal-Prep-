using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class HydrationLog
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Drank first liter")]
        public bool drankOneLiter { get; set; }

        [Display(Name = "Drank second liter")]
        public bool drankSecondLiter { get; set; }

        [Display(Name = "Drank third liter")]
        public bool drankThirdLiter { get; set; }

        [Display(Name = "Drank fourth liter")]
        public bool drankFourthLiter { get; set; }
    }
}
