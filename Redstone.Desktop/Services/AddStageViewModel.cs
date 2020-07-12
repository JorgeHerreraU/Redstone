using AutoMapper;
using Redstone.Domain.Models;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Redstone.Desktop.Services
{
    public class AddStageViewModel : BindableBase
    {
        private IRepository<Stage> _stageRepo;
        private IRepository<Team> _teamRepo;
        private IRepository<Supply> _supplyRepo;
        private IMapper _mapper;
        private ObservableCollection<Stagesupply> _stagesupplies;
        public ObservableCollection<Stagesupply> Stagesupplies
        {
            get => _stagesupplies;
            set
            {
                _stagesupplies = value;
                NotifyPropertyChanged();
            }
        }
        private Stagesupply _stageSupply;
        public Stagesupply Stagesupply
        {
            get => _stageSupply;
            set
            {
                _stageSupply = value;
                NotifyPropertyChanged();
            }
        }
        private int _itemQuantity;
        public int ItemQuantity
        {
            get => _itemQuantity;
            set
            {
                _itemQuantity = value;
                NotifyPropertyChanged();
            }
        }

        private Supply _selectedSupply;
        public Supply SelectedSupply
        {
            get => _selectedSupply;
            set
            {
                _selectedSupply = value;
                NotifyPropertyChanged();
            }
        }

        private Team _selectedTeam;
        public Team SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                _selectedTeam = value;
                NotifyPropertyChanged();
                BlackListDates();
                CalculatePrice();
            }
        }
        private ObservableCollection<Team> _teams;
        public ObservableCollection<Team> Teams
        {
            get => _teams;
            set
            {
                _teams = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Supply> _supplies;
        public ObservableCollection<Supply> Supplies
        {
            get => _supplies;
            set
            {
                _supplies = value;
                NotifyPropertyChanged();
            }
        }
        private Models.Stage _stage;
        public Models.Stage Stage
        {
            get => _stage;
            set
            {
                _stage = value;
                NotifyPropertyChanged();
            }
        }
        private int _totalPrice;
        public int TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand AddStageCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand<Supply> AddSupply { get; set; }
        public RelayCommand<Stagesupply> RemoveSupply { get; set; }
        public Action Done { get; set; } = delegate { };
        public AddStageViewModel(
            IRepository<Stage> stageRepo,
            IRepository<Team> teamRepo,
            IRepository<Supply> supplyRepo,
            IMapper mapper)
        {
            _stageRepo = stageRepo;
            _teamRepo = teamRepo;
            _supplyRepo = supplyRepo;
            _mapper = mapper;
            AddStageCommand = new RelayCommand(OnAdd, CanAdd);
            CancelCommand = new RelayCommand(OnCancel);
            AddSupply = new RelayCommand<Supply>(OnAddSupply);
            RemoveSupply = new RelayCommand<Stagesupply>(OnRemoveSupply);
            Stagesupplies = new ObservableCollection<Stagesupply>();
            LoadTeams();
            LoadSupplies();
        }

        public void RaiseCanChange(object sender, EventArgs e)
        {
            AddStageCommand.RaiseCanExecuteChanged();
        }

        public async void LoadSupplies()
        {
            var supplies = await _supplyRepo.GetAll();
            supplies.OrderBy(x => x.Name);
            Supplies = new ObservableCollection<Supply>(supplies);
        }

        public async void LoadTeams()
        {
            var teams = await _teamRepo.GetAll();
            Teams = new ObservableCollection<Team>(teams);
        }

        public async void BlackListDates()
        {
            Stage.BlackList.Clear();
            var teamStages = await _stageRepo.GetWhere(x => x.TeamId == SelectedTeam.Id);
            List<Stage> stages = teamStages.ToList();
            foreach (var row in stages)
            {
                var dt = row.Schedule ?? DateTime.Now;
                Stage.BlackList.Add(dt);
            }
        }

        public void CalculatePrice()
        {
            var teamFee = SelectedTeam.Fee ?? 0;
            int suppliesPrice = 0;
            foreach (var item in Stagesupplies)
            {
                suppliesPrice += (item.Supply.Unitprice * item.Quantity);
            }
            TotalPrice = teamFee + suppliesPrice;
        }

        public void SetNewStage(Service service)
        {
            Stage = new Models.Stage
            {
                Id = service.Id
            };
            Stage.ErrorsChanged += RaiseCanChange;
            TotalPrice = 0;
        }

        public void OnAdd()
        {

        }

        private bool CanAdd()
        {
            return !Stage.HasErrors;
        }

        public void OnCancel()
        {
            Stagesupplies.Clear();
            Done();
        }

        public void OnAddSupply(Supply supply)
        {
            Stagesupply stagesupply = new Stagesupply
            {
                StageId = Stage.Id,
                Quantity = ItemQuantity,
                SupplyId = supply.Id,
                Supply = supply
            };
            Stagesupplies.Add(stagesupply);
            CalculatePrice();
        }

        public void OnRemoveSupply(Stagesupply stageSupply)
        {
            Stagesupplies.Remove(stageSupply);
            CalculatePrice();
        }
    }
}
