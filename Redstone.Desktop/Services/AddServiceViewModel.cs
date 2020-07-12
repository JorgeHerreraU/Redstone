using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Services
{
    public class AddServiceViewModel : BindableBase
    {
        private IRepository<ServiceOffered> _servicesRepo;
        private IRepository<Service> _repo;
        private ServiceOffered _selectedService;
        public ServiceOffered SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                NotifyPropertyChanged();
            }
        }
        public List<ServiceOffered> Services { get; set; }
        public Customer Customer { get; set; }

        private Service _service;
        public Service Service
        {
            get => _service;
            set
            {
                _service = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand AddServiceCommand { get; private set; }
        public event Action Done = delegate { };

        public AddServiceViewModel(IRepository<Service> repo, IRepository<ServiceOffered> servicesRepo)
        {
            _repo = repo;
            _servicesRepo = servicesRepo;
            LoadOfferedServices();
            CancelCommand = new RelayCommand(OnCancel);
            AddServiceCommand = new RelayCommand(OnAdd);
        }

        public void SetCustomer(Customer customer)
        {
            Customer = new Customer
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname
            };
            Service = new Service
            {
                CustomerId = customer.Id
            };
        }

        public async void LoadOfferedServices()
        {
            Services = new List<ServiceOffered>();
            Services = (List<ServiceOffered>)await _servicesRepo.GetAll();
        }

        public void OnCancel()
        {
            Done();
        }

        public async void OnAdd()
        {
            Service.ServiceofferedId = SelectedService.Id;
            await _repo.Add(Service);
            Done();
        }
    }

}
