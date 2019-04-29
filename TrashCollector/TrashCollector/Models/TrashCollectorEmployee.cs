using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class TrashCollectorEmployee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string AspUserId { get; set; }
        [Required]
        [Display(Name = "Route By Zip")]
        public int RouteZipCode { get; set; }
        [Display(Name = "My Route Day")]
        public PickupWeek RouteDay { get; set; }
        [Required]
        [Display(Name = "Pickup Status")]
        public PickupStatus PickupStatus { get; set; }
        public IEnumerable<int> ZipCodeSelected { get; set; }
    }
}