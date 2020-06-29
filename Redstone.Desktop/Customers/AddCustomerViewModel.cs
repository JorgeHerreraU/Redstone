using AutoMapper;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Customers
{
    public class AddCustomerViewModel : BindableBase
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
        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action Done = delegate { };

        public AddCustomerViewModel(IRepository<Customer> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
            
            AddCustomerCommand = new RelayCommand(AddCustomer, CanAdd);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public void RaiseCanChange(object sender, EventArgs e)
        {
            AddCustomerCommand.RaiseCanExecuteChanged();
        }

        public void SetNewCustomer()
        {
            Customer = new Models.Customer();
            Customer.ErrorsChanged += RaiseCanChange;
            Customer.Address.ErrorsChanged += RaiseCanChange;
        }

        public async void AddCustomer()
        {
            await _repo.Add(_mapper.Map<Customer>(Customer));
            Done();
        }

        public void OnCancel()
        {
            Done();
        }

        private bool CanAdd()
        {
            return !Customer.HasErrors & !Customer.Address.HasErrors;
        }
    }
}
