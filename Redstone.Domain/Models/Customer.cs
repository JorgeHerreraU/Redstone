using System;
using System.Collections.Generic;

namespace Redstone.Domain.Models
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            Service = new HashSet<Service>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
