using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Redstone.Desktop.Customers
{
    public class CustomerViewModel : BindableBase
    {
        private IRepository<Customer> _repo;
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerViewModel(IRepository<Customer> repository)
        {
            _repo = repository;
            LoadCustomers();
        }

        public async void LoadCustomers()
        {
            var customers = await _repo.GetAll();
            Customers = new ObservableCollection<Customer>(customers);
        }
    }
}
