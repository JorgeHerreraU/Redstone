using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Customer : ValidatableBase
    {
        public int Id { get; set; }
        public Customer()
        {
            Address = new Address();
            Service = new HashSet<Service>();
            Firstname = "";
            Lastname = "";
            Phone = "";
            Email = "";
        }

        private string _firstname;
        [Required]
        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                NotifyPropertyChanged();
            }
        }
        private string _lastname;
        [Required]
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                NotifyPropertyChanged();
            }
        }
        private string _email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }
        private string _phone;
        [Required]
        [Phone]
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyPropertyChanged();
            }
        }

        public Address Address { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}
