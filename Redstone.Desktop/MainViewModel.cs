using Redstone.Desktop.Customers;
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

        public MainViewModel
        (
            CustomerViewModel customerViewModel,
            AddCustomerViewModel addCustomerViewModel,
            EditCustomerViewModel editCustomerViewModel
        )
        {
            _customerViewModel = customerViewModel;
            _addCustomerViewModel = addCustomerViewModel;
            _editCustomerViewModel = editCustomerViewModel;

            _customerViewModel.OnAddCustomerRequested += NavToAddCustomer;
            _customerViewModel.OnEditCustomerRequested += NavToEditCustomer;
            _addCustomerViewModel.Done += OpenCustomerView;
            _editCustomerViewModel.Done += OpenCustomerView;

            GoToCustomer = new RelayCommand(OpenCustomerView);
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
    }
}
