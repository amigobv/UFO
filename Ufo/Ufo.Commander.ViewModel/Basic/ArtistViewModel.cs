using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class ArtistViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Artist artist;
        private ObservableCollection<CategoryViewModel> categories;
        #endregion

        #region ctor
        public ArtistViewModel(IManager manager)
        {
            this.artist = new Artist();
            this.manager = manager;
            categories = new ObservableCollection<CategoryViewModel>();
            SaveCommand = new RelayCommand((o) => manager.UpdateArtist(artist));
            RemoveCommand = new RelayCommand((o) => { });
    }

        public ArtistViewModel(Artist artist, IManager manager)
        {
            this.artist = artist;
            this.manager = manager;
            categories = new ObservableCollection<CategoryViewModel>();
        }
        #endregion

        #region properties
        public int Id
        {
            get { return artist.Id; }
            set
            {
                if (artist.Id != value)
                {
                    artist.Id = value;
                    RaisePropertyChangedEvent(nameof(Id));
                }
            }
        }

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

        public ObservableCollection<CategoryViewModel> Categories
        {
            get
            { 
                LoadCategories();
                return categories;
            }
            set
            {
                if (categories != value)
                {
                    categories = value;
                    RaisePropertyChangedEvent(nameof(Categories));
                }
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion

        private void LoadCategories()
        {
            categories.Clear();
            var listCategories = manager.GetAllCategories();

            foreach (var category in listCategories)
                categories.Add(new CategoryViewModel(category, manager));

        }
    }
}
