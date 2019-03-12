using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class TrashCollectorEmployee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AspUserId { get; set; }
        public int ZipCode { get; set; }
        public IEnumerable<int> ZipCodeSelected { get; set; }
    }
}