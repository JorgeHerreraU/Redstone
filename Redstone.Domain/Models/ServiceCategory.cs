using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class ServiceCategory : BaseEntity
    {
        public string Description { get; set; }

        public virtual ServiceOffered ServiceOffered { get; set; }
        public virtual Team Team { get; set; }
    }
}
