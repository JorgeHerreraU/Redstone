using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Service
    {
        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public int ServiceofferedId { get; set; }
        public Guid? CartId { get; set; }

        // public Customer Customer { get; set; }
        // public ICollection<Stage> Stage { get; set; }
        // public ServiceOffered Serviceoffered { get; set; }
    }
}
