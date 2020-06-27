using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Report : BaseEntity
    {
        public string Soil { get; set; }
        public string Relief { get; set; }
        public string Rocks { get; set; }
        public string Water { get; set; }
        public string Wind { get; set; }
        public string Plants { get; set; }
        public string Vegetation { get; set; }
        public int? StageId { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
