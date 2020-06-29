using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Service
    {
        public Service()
        {
            Stage = new HashSet<Stage>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
    }
}
