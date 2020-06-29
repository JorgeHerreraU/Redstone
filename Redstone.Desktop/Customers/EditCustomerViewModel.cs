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
        private IMapper _mapper;
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

        public RelayCommand SaveCustomerCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done = delegate { };

        public EditCustomerViewModel(IRepository<Customer> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCustomerCommand = new RelayCommand(OnSave, CanSave);
        }

        public void RaiseCanChange(object sender, EventArgs e)
        {
            SaveCustomerCommand.RaiseCanExecuteChanged();
        }

        private Customer _editingCustomer = null;
        public void SetCurrentCustomer(Customer customer)
        {
            _editingCustomer = customer;
            Customer = new Models.Customer();
            Customer = _mapper.Map<Models.Customer>(customer);
            Customer.ErrorsChanged += RaiseCanChange;
            Customer.Address.ErrorsChanged += RaiseCanChange;
        }

        public async void OnSave()
        {
            _editingCustomer = _mapper.Map(Customer, _editingCustomer);
            await _repo.Update(_editingCustomer);
            Done();
        }

        public void OnCancel()
        {
            Done();
        }

        private bool CanSave()
        {
            return !Customer.HasErrors & !Customer.Address.HasErrors;
        }
    }
}
