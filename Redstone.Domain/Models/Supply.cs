using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Supply : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Unitprice { get; set; }
        public string Category { get; set; }
    }
}
