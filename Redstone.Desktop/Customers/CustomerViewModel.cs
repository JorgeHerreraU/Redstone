using Accessibility;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Redstone.Desktop.Controls;
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
        private IRepository<Customer> _repoCustomers;
        private IRepository<Address> _repoAddress;
        private IDialogService _dialogService;
        private IMapper _mapper;


        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                NotifyPropertyChanged();
                RemoveCustomerCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand<Customer> EditCustomerCommand { get; set; }
        public RelayCommand<Customer> RemoveCustomerCommand { get; set; }
        public RelayCommand AddServiceCommand { get; set; }
        public event Action OnAddCustomerRequested = delegate { };
        public event Action<Customer> OnEditCustomerRequested = delegate { };

        public CustomerViewModel(IRepository<Customer> repositoryCustomers, IRepository<Address> repositoryAddress, IDialogService dialogService, IMapper mapper)
        {
            _repoCustomers = repositoryCustomers;
            _repoAddress = repositoryAddress;
            _dialogService = dialogService;
            _mapper = mapper;
            RemoveCustomerCommand = new RelayCommand<Customer>(OnRemove);
            AddCustomerCommand = new RelayCommand(AddCustomerRequested);
            EditCustomerCommand = new RelayCommand<Customer>(EditCustomerRequested);
        }

        public async void LoadCustomers()
        {
            var customers = await _repoCustomers.GetAll();
            Customers = new ObservableCollection<Customer>(customers);
        }

        public async void OnRemove(Customer customer)
        {
            var result = _dialogService.ShowConfirmationDialog($"¿Está seguro que desea eliminar al cliente {customer.Fullname}?");
            if (result)
            {
                await _repoCustomers.Remove(customer);
                Customers.Remove(customer);
            }
        }

        public void AddCustomerRequested()
        {
            OnAddCustomerRequested();
        }

        public async void EditCustomerRequested(Customer customer)
        {
            customer.Address = new Address();
            customer.Address = await _repoAddress.FirstOrDefault(a => a.CustomerId == customer.Id);
            OnEditCustomerRequested(customer);
        }
    }
}
