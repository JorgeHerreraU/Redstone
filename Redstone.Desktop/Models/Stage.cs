using Redstone.Data.Services;
using Redstone.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Redstone.Desktop.Models
{
    public class Stage : ValidatableBase, IDataErrorInfo
    {
        public List<DateTime> BlackList { get; set; } = new List<DateTime>();
        public int Id { get; set; }
        private string _name;
        [Required]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        [Required]
        private DateTime _schedule;
        public DateTime Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                NotifyPropertyChanged();
            }
        }

        public string this[string name]
        {
            get
            {
                string result = String.Empty;
                if (name == "Schedule")
                {
                    if (Schedule < DateTime.Now)
                    {
                        result = "Fecha Debe Ser Mayor a la Fecha Actual";
                    }
                    if (BlackList.Any(x => x.Date == Schedule.Date))
                    {
                        result = "Fecha Ocupada";
                    }

                }

                return result;
            }
        }

        private int _teamid;
        public int TeamId
        {
            get => _teamid;
            set
            {
                _teamid = value;
                NotifyPropertyChanged();
            }
        }

        public string Error => string.Empty;

        public Stage()
        {
            Name = "";
            Schedule = DateTime.Now;

        }
    }
}