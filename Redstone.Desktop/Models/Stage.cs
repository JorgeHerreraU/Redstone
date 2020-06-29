using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Stage
    {
        public Stage()
        {
            Payment = new HashSet<Payment>();
        }

        public string Name { get; set; }
        public DateTime Schedule { get; set; }
        public int ServiceId { get; set; }
        public int TeamId { get; set; }
        public bool IsPaid { get; set; }
        public int Ammount { get; set; }

        public virtual Service Service { get; set; }
        public virtual Team Team { get; set; }
        public virtual Report Report { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
