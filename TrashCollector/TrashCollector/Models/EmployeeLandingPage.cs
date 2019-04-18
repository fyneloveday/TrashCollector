using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeLandingPage
    {
        public TrashCollectorEmployee TrashCollectorEmployee { get; set; }
        public List<TrashCollectorCustomer> CustomersByZip { get; set; }
    }
}