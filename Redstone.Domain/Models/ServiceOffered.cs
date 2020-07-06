using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class ServiceOffered : BaseEntity
    {
        public ServiceOffered()
        {
            Service = new HashSet<Service>();
        }

        public string Name { get; set; }
        public int? BasePrice { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }

        public virtual ServiceCategory Category { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
