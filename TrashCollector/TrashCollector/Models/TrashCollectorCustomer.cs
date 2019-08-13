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
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        public string AspUserId { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        [Required]
        [Display(Name = "Pickup Day")]
        public PickupWeek PickupDay { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Backup Pickup Day")]
        public DateTime? BackupPickupDay { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Of Pickup Suspension")]
        public DateTime? StartPickupSuspension { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Of Pickup Suspension")]
        public DateTime? EndPickupSuspension { get; set; }
        [Required]
        [Display(Name = "Pickup Status")]
        public PickupStatus PickupStatus { get; set; }
        public double Bill { get; set; }
    }
}
