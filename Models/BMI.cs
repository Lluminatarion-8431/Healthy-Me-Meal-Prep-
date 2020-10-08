using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class BMI
    {

        public class Rootobject
        {
            public Weight weight { get; set; }
            public Height height { get; set; }
            public Bmi bmi { get; set; }
            public string ideal_weight { get; set; }
            public string surface_area { get; set; }
            public string ponderal_index { get; set; }
            public Bmr bmr { get; set; }
            public Whr whr { get; set; }
            public Whtr whtr { get; set; }
        }

        public class Weight
        {
            public string kg { get; set; }
            public string lb { get; set; }
        }

        public class Height
        {
            public string m { get; set; }
            public string cm { get; set; }
            public string _in { get; set; }
            public string ftin { get; set; }
        }

        public class Bmi
        {
            public string value { get; set; }
            public string status { get; set; }
            public string risk { get; set; }
            public string prime { get; set; }
        }

        public class Bmr
        {
            public string value { get; set; }
        }

        public class Whr
        {
            public string value { get; set; }
            public string status { get; set; }
        }

        public class Whtr
        {
            public string value { get; set; }
            public string status { get; set; }
        }

    }
}
