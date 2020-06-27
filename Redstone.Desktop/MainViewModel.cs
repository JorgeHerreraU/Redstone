using Redstone.Desktop.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop
{
    public class MainViewModel : BindableBase
    {
        private CustomerViewModel _customerViewModel;
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
            CustomerViewModel customerViewModel
        )
        {
            _customerViewModel = customerViewModel;

            GoToCustomer = new RelayCommand(OpenCustomerView);
        }

        private void OpenCustomerView()
        {
            SelectedViewModel = _customerViewModel;
        }
    }
}
