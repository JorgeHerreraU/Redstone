using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Team : BaseEntity
    {
        public Team()
        {
            Stage = new HashSet<Stage>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Fee { get; set; }

        public virtual ICollection<Stage> Stage { get; set; }
    }
}
