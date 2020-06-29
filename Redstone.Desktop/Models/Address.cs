using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Address : ValidatableBase
    {
        private string _street;
        [Required]
        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                NotifyPropertyChanged();
            }
        }
        private int _number;
        [Required]
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                NotifyPropertyChanged();
            }
        }
        private string _apartment;
        public string Apartment
        {
            get => _apartment;
            set
            {
                _apartment = value;
                NotifyPropertyChanged();
            }
        }
        private string _district;
        public string District
        {
            get => _district;
            set
            {
                _district = value;
                NotifyPropertyChanged();
            }
        }
        private string _city;
        [Required]
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyPropertyChanged();
            }
        }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Address()
        {
            Street = "";
            Number = 0;
            City = "";
        }
    }
}
