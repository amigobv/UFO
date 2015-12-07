using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Commander.Model;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.ViewModel
{
    public class ArtistViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Artist artist;
        private ObservableCollection<Category> categories;
        #endregion

        #region ctor
        public ArtistViewModel()
        {
            artist = new Artist();
            manager = ManagerFactory.GetManager();
            Categories = manager.GetAllCategories();
            SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
        }

        public ArtistViewModel(Artist artist)
        {
            this.artist = artist;
            manager = ManagerFactory.GetManager();
            Categories = manager.GetAllCategories();
            SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
        }
        #endregion

        #region properties
        public string Name
        {
            get { return artist.Name; }
            set
            {
                if (artist.Name != value)
                {
                    artist.Name = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
        }

        public string Country
        {
            get { return artist.Country; }
            set
            {
                if (artist.Country != value)
                {
                    artist.Country = value;
                    RaisePropertyChangedEvent(nameof(Country));
                }
            }
        }

        public string Email
        {
            get { return artist.Email; }
            set
            {
                if (artist.Email != value)
                {
                    artist.Email = value;
                    RaisePropertyChangedEvent(nameof(Email));
                }   
            }
        }

        public string Description
        {
            get { return artist.Description; }
            set
            {
                if (artist.Description != value)
                {
                    artist.Description = value;
                    RaisePropertyChangedEvent(nameof(Description));
                }
            }
        }

        public string Homepage
        {
            get { return artist.Homepage; }
            set
            {
                if (artist.Homepage != value)
                {
                    artist.Homepage = value;
                    RaisePropertyChangedEvent(nameof(Homepage));
                }
            }
        }

        public string Picture
        {
            get { return artist.PictureUrl; }
            set
            {
                if (artist.PictureUrl != value)
                {
                    artist.PictureUrl = value;
                    RaisePropertyChangedEvent(nameof(Picture));
                }
            }
        }

        public string Video
        {
            get { return artist.VideoUrl; }
            set
            {
                if (artist.VideoUrl != value)
                {
                    artist.VideoUrl = value;
                    RaisePropertyChangedEvent(nameof(Video));
                }
            }
        }

        public Category Category
        {
            get { return artist.Category; }
            set
            {
                if (artist.Category != value)
                {
                    artist.Category = value;
                    RaisePropertyChangedEvent(nameof(Category));
                }
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ICommand SaveCommand { get; set; }
        #endregion
    }
}
