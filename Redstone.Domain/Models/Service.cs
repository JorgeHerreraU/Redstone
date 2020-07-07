using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Service : BaseEntity
    {
        public Service()
        {
            Stage = new HashSet<Stage>();
        }

        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public int ServiceofferedId { get; set; }
        public Guid? CartId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ServiceOffered Serviceoffered { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
    }
}
