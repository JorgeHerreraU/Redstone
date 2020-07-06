using Accessibility;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Redstone.Desktop.Controls;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Redstone.Desktop.Customers
{
    public class CustomerViewModel : BindableBase
    {
        private IRepository<Customer> _repoCustomers;
        private IRepository<Address> _repoAddress;
        private IDialogService _dialogService;


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
        private List<Customer> _allCustomers;
        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set
            {
                _searchInput = value;
                NotifyPropertyChanged();
                FilterClients(_searchInput);
            }
        }
        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand<Customer> EditCustomerCommand { get; set; }
        public RelayCommand<Customer> RemoveCustomerCommand { get; set; }
        public RelayCommand<Customer> AddServiceCommand { get; set; }
        public RelayCommand ClearSearchCommand { get; set; }
        public event Action OnAddCustomerRequested = delegate { };
        public event Action<Customer> OnEditCustomerRequested = delegate { };
        public event Action<Customer> OnAddServiceRequested = delegate { };

        public CustomerViewModel
            (
            IRepository<Customer> repositoryCustomers,
            IRepository<Address> repositoryAddress,
            IDialogService dialogService
            )
        {
            _repoCustomers = repositoryCustomers;
            _repoAddress = repositoryAddress;
            _dialogService = dialogService;
            RemoveCustomerCommand = new RelayCommand<Customer>(OnRemove);
            AddCustomerCommand = new RelayCommand(AddCustomerRequested);
            EditCustomerCommand = new RelayCommand<Customer>(EditCustomerRequested);
            ClearSearchCommand = new RelayCommand(OnClearSearch);
            AddServiceCommand = new RelayCommand<Customer>(AddServiceRequested);
        }

        public async void LoadCustomers()
        {
            _allCustomers = (List<Customer>)await _repoCustomers.GetAll();
            Customers = new ObservableCollection<Customer>(_allCustomers);
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

        private void FilterClients(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Customers = new ObservableCollection<Customer>(_allCustomers);
                return;
            }
            else
            {
                Customers = new ObservableCollection<Customer>(_allCustomers.Where(c => c.Fullname.ToLower().Contains(searchInput.ToLower())));
            }
        }
        public void OnClearSearch()
        {
            SearchInput = null;
        }

        public void AddServiceRequested(Customer customer)
        {
            OnAddServiceRequested(customer);
        }
    }
}
