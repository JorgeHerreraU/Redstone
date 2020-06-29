using AutoMapper;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Customers
{
    public class EditCustomerViewModel : BindableBase
    {
        private IRepository<Customer> _repo;
        private Models.Customer _customer;
        public Models.Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand SaveCustomerCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action Done = delegate { };

        public EditCustomerViewModel(IRepository<Customer> repository)
        {
            _repo = repository;
            CancelCommand = new RelayCommand(OnCancel);
        }

        public void RaiseCanChange(object sender, EventArgs e)
        {
            SaveCustomerCommand.RaiseCanExecuteChanged();
        }

        public void SetCurrentCustomer(Models.Customer customer)
        {
            Customer = customer;
            SaveCustomerCommand = new RelayCommand(UpdateCustomer, CanSave);
        }

        public async void UpdateCustomer()
        {
            
        }

        public void OnCancel()
        {
            Done();
        }

        private bool CanSave()
        {
            return true;
            // return !Customer.HasErrors & !Customer.Address.HasErrors;
        }
    }
}
