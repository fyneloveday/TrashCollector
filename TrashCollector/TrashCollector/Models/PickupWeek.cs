using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupWeek
    {
        [Display(Name = "Monday")]
        public string Mondaay { get; set; }
        [Display(Name = "Tuesday")]
        public string Tuesday { get; set; }
        [Display(Name = "Wednesday")]
        public string Wednesday { get; set; }
        [Display(Name = "Thursday")]
        public string Thursday { get; set; }
        [Display(Name = "Friday")]
        public string Friday { get; set; }
    }
}