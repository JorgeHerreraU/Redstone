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
    public class StageViewModel : BindableBase
    {
        private IRepository<Stage> _stageRepo;
        public string CustomerFullName { get; set; }
        public string ServiceName { get; set; }
        public DateTime RequestedDate { get; set; }
        private int _serviceId;
        private ObservableCollection<Stage> _stages;
        public ObservableCollection<Stage> Stages
        {
            get => _stages;
            set
            {
                _stages = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand<Stage> UpdateStatusCommand { get; set; }
        public StageViewModel(IRepository<Stage> stageRepo)
        {
            _stageRepo = stageRepo;
        }

        public void SetService(Service service)
        {
            _serviceId = service.Id;
            CustomerFullName = service.Customer.Fullname;
            ServiceName = service.Serviceoffered.Name;
            RequestedDate = service.RequestDate;
            UpdateStatusCommand = new RelayCommand<Stage>(UpdateStatus);
        }

        public void LoadStages()
        {
            var data = _stageRepo.QueryAll().Include(s => s.Service).Include(t => t.Team).Where(x => x.ServiceId == _serviceId);
            Stages = new ObservableCollection<Stage>(data);

        }

        public void UpdateStatus(Stage stage)
        {
            _stageRepo.Update(stage);
        }

    }

    
}
