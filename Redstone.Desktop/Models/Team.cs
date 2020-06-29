using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Team
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
