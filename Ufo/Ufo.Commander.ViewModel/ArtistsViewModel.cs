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
        private ObservableCollection<ArtistEditViewModel> artists;
        private IManager manager;
        private ArtistEditViewModel currentArtist;
        #endregion

        #region ctor
        public ArtistsViewModel(IManager manager)
        {
            this.manager = manager;
            artists = new ObservableCollection<ArtistEditViewModel>();
            currentArtist = new ArtistEditViewModel(new Artist(), manager);
            LoadArtists();
        }
        #endregion

        #region properties
        public ObservableCollection<ArtistEditViewModel> Artists
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

        public ArtistEditViewModel CurrentArtist
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

        public void LoadArtists()
        {
            Artists.Clear();
            var artistsList = manager.GetAllArtists();

            foreach (var artist in artistsList)
            {
                Artists.Add(new ArtistEditViewModel(artist, manager));
            }

        }
    }
}
