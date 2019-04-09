using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public enum PickupWeek
    {
        [Display(Name = "Monday")]
        Monday,
        [Display(Name = "Tuesday")]
        Tuesday,
        [Display(Name = "Wednesday")]
        Wednesday,
        [Display(Name = "Thursday")]
        Thursday,
        [Display(Name = "Friday")]
        Friday,
    }
}