using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class LocationViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Location location;
        #endregion

        #region ctor
        public LocationViewModel(IManager manager)
        {
            this.manager = manager;
            this.location = new Location();
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
        }

        public LocationViewModel(Location location, IManager manager)
        {
            this.manager = manager;
            this.location = location;
            SaveCommand = new RelayCommand(o => manager.UpdateLocation(location));
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
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var location = obj as LocationViewModel;

            if (location == null)
                return false;


            return location.Equals(this.location);
        }
    }
}
