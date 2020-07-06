using Redstone.Desktop.Customers;
using Redstone.Desktop.Services;
using Redstone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop
{
    public class MainViewModel : BindableBase
    {
        private CustomerViewModel _customerViewModel;
        private AddCustomerViewModel _addCustomerViewModel;
        private EditCustomerViewModel _editCustomerViewModel;
        private ServiceViewModel _serviceViewModel;
        private AddServiceViewModel _addServiceViewModel;
        private BindableBase _selectedViewModel;
        public BindableBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand GoToCustomer { get; set; }
        public RelayCommand GoToServices { get; set; }

        public MainViewModel
        (
            CustomerViewModel customerViewModel,
            AddCustomerViewModel addCustomerViewModel,
            EditCustomerViewModel editCustomerViewModel,
            ServiceViewModel serviceViewModel,
            AddServiceViewModel addServiceViewModel
        )
        {
            _customerViewModel = customerViewModel;
            _addCustomerViewModel = addCustomerViewModel;
            _editCustomerViewModel = editCustomerViewModel;
            _serviceViewModel = serviceViewModel;
            _addServiceViewModel = addServiceViewModel;

            _customerViewModel.OnAddCustomerRequested += NavToAddCustomer;
            _customerViewModel.OnEditCustomerRequested += NavToEditCustomer;
            _customerViewModel.OnAddServiceRequested += NavToAddService;
            _addCustomerViewModel.Done += OpenCustomerView;
            _editCustomerViewModel.Done += OpenCustomerView;

            GoToCustomer = new RelayCommand(OpenCustomerView);
            GoToServices = new RelayCommand(OpenServicesView);
        }

        private void OpenCustomerView()
        {
            SelectedViewModel = _customerViewModel;
        }

        private void NavToAddCustomer()
        {
            _addCustomerViewModel.SetNewCustomer();
            SelectedViewModel = _addCustomerViewModel;
        }

        private void NavToEditCustomer(Customer customer)
        {
            _editCustomerViewModel.SetCurrentCustomer(customer);
            SelectedViewModel = _editCustomerViewModel;
        }

        private void NavToAddService(Customer customer)
        {
            SelectedViewModel = _addServiceViewModel;
        }

        private void OpenServicesView()
        {
            SelectedViewModel = _serviceViewModel;
        }
    }
}
