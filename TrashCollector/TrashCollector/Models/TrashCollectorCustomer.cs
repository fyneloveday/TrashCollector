using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class TrashCollectorCustomer
    {
       // [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}