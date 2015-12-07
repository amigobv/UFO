using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ArtistsViewModel : ViewModelBase
    {
        #region privae members
        private ObservableCollection<ArtistViewModel> artists;
        private IManager manager;
        private ArtistViewModel currentArtist;
        #endregion

        #region ctor
        public ArtistsViewModel()
        {
            manager = ManagerFactory.GetManager();
            artists = new ObservableCollection<ArtistViewModel>();
            currentArtist = new ArtistViewModel(new Artist());
            LoadArtists();
        }
        #endregion

        public void LoadArtists()
        {
            Artists.Clear();
            var artistsList = manager.GetAllArtists();

            foreach (var artist in artistsList)
            {
                Artists.Add(new ArtistViewModel(artist));
            }

        }

        #region properties
        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return artists; }
            set
            {
                if (artists != value)
                {
                    artists = value;
                    RaisePropertyChangedEvent(nameof(Artists));
                }
            }
        }

        public ArtistViewModel CurrentArtist
        {
            get { return currentArtist; }
            set
            {
                if (currentArtist != value)
                {
                    currentArtist = value;
                    RaisePropertyChangedEvent(nameof(CurrentArtist));
                }
            }
        }
        #endregion
    }
}
