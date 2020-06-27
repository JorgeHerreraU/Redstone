using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Stagesupply
    {
        public int StageId { get; set; }
        public int SupplyId { get; set; }
        public int Quantity { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
