using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Stage : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? Schedule { get; set; }
        public int ServiceId { get; set; }
        public int TeamId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCompleted { get; set; }
        public int Ammount { get; set; }
        public virtual Service Service { get; set; }
        public virtual Team Team { get; set; }
        public virtual Report Report { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
