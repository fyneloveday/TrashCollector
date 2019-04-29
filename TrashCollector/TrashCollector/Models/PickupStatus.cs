using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public enum PickupStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Done")]
        Done,
    }
}