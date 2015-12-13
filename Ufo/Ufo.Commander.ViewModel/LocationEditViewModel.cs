using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class LocationEditViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Location location;
        #endregion

        #region ctor
        public LocationEditViewModel(IManager manager)
        {
            this.manager = manager;
            this.location = new Location();
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
            RemoveCommand = new RelayCommand(o => manager.RemoveLocation(location), o => manager.LocationExists(location) == false);
        }

        public LocationEditViewModel(Location location, IManager manager)
        {
            this.manager = manager;
            this.location = location;
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
            RemoveCommand = new RelayCommand(o => manager.RemoveLocation(location), o => manager.LocationExists(location) == false);
        }
        #endregion

        #region properties
        public string Identifier
        {
            get { return location.Id; }
            set
            {
                if (location.Id != value)
                {
                    location.Id = value;
                    RaisePropertyChangedEvent(nameof(Identifier));
                }
            }
        }

        public string Name
        {
            get { return location.Label; }
            set
            {
                if (location.Label != value)
                {
                    location.Label = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion
    }
}
