using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Basic;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ArtistsViewModel : ViewModelBase
    {
        #region private members
        private ObservableCollection<ArtistViewModel> artists;
        private IManager manager;
        private ArtistViewModel currentArtist;
        #endregion

        #region ctor
        public ArtistsViewModel(IManager manager)
        {
            this.manager = manager;
            artists = new ObservableCollection<ArtistViewModel>();
            currentArtist = new ArtistViewModel(new Artist(), manager);
        }
        #endregion

        #region properties
        public ObservableCollection<ArtistViewModel> Artists
        {
            get
            {
                return artists;
            }
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
                    currentArtist.NotifyUpdate -= LoadArtists;
                    currentArtist.NotifyDelete -= LoadArtists;

                    currentArtist = value;
                    RaisePropertyChangedEvent(nameof(CurrentArtist));

                    if (currentArtist != null)
                    {
                        currentArtist.NotifyUpdate += LoadArtists;
                        currentArtist.NotifyDelete += LoadArtists;
                    }
                }
            }
        }
        #endregion

        public void LoadArtists()
        {
            artists.Clear();
            var artistsList = manager.GetAllArtists();

            foreach (var artist in artistsList)
            {
                artists.Add(new ArtistViewModel(artist, manager));
            }

            Artists = artists;
        }
    }
}
