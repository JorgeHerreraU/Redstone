﻿using Redstone.Desktop.Customers;
using Redstone.Desktop.Services;
using Redstone.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private StageViewModel _stageViewModel;
        private BindableBase _selectedViewModel;
        private AddStageViewModel _addStageViewModel;
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
            AddServiceViewModel addServiceViewModel,
            StageViewModel stageViewModel,
            AddStageViewModel addStageViewModel
        )
        {
            _customerViewModel = customerViewModel;
            _addCustomerViewModel = addCustomerViewModel;
            _editCustomerViewModel = editCustomerViewModel;
            _serviceViewModel = serviceViewModel;
            _addServiceViewModel = addServiceViewModel;
            _stageViewModel = stageViewModel;
            _addStageViewModel = addStageViewModel;

            _customerViewModel.OnAddCustomerRequested += NavToAddCustomer;
            _customerViewModel.OnEditCustomerRequested += NavToEditCustomer;
            _customerViewModel.OnAddServiceRequested += NavToAddService;
            _addCustomerViewModel.Done += OpenCustomerView;
            _editCustomerViewModel.Done += OpenCustomerView;
            _addServiceViewModel.Done += OpenCustomerView;
            _addStageViewModel.Done += OpenServicesView;
            _serviceViewModel.OnViewStageRequested += NavToStageView;
            _serviceViewModel.OnAddStageRequested += NavToAddStageView;

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
            _addServiceViewModel.SetCustomer(customer);
            SelectedViewModel = _addServiceViewModel;
        }

        private void OpenServicesView()
        {
            SelectedViewModel = _serviceViewModel;
        }

        private void NavToStageView(Service service)
        {
            _stageViewModel.SetService(service);
            SelectedViewModel = _stageViewModel;
        }

        private void NavToAddStageView(Service service)
        {
            _addStageViewModel.SetNewStage(service);
            SelectedViewModel = _addStageViewModel;
        }
    }
}
