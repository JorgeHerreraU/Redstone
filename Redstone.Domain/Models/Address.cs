using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Address : BaseEntity
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Apartment { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
