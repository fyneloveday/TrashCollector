using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Models
{
    public class TrashCollectorCustomer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        public string AspUserId { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Required]
        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }
        public IEnumerable<SelectListItem> DaysOfTheWeek { get; set; }
        public double Bill { get; set; }
    }
}