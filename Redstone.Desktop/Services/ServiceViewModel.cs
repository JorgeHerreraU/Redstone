using Microsoft.EntityFrameworkCore;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Redstone.Desktop.Services
{
    public class ServiceViewModel : BindableBase
    {
        private IRepository<Service> _serviceRepo;
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set
            {
                _services = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand<Service> ViewStageCommand { get; set; }
        public Action<Service> OnViewStageRequested = delegate { };
        
        public ServiceViewModel(IRepository<Service> serviceRepo)
        {
            _serviceRepo = serviceRepo;
            ViewStageCommand = new RelayCommand<Service>(ViewStage);
        }

        public void LoadServices()
        {
            var data = _serviceRepo.QueryAll().Include(c => c.Customer).Include(s => s.Serviceoffered).ToList();
            Services = new ObservableCollection<Service>(data);
        }

        public void ViewStage(Service service)
        {
            OnViewStageRequested(service);
        }

    }
}
