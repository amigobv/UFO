using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Ufo.BL.Interfaces;
using Ufo.Command.ViewModel;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel.Basic
{
    public class ArtistViewModel : ViewModelBase
    {
        #region private members
        private IManager manager;
        private Artist artist;
        private CategoryViewModel category;
        private ObservableCollection<CategoryViewModel> categories;
        #endregion

        #region ctor
        public ArtistViewModel(IManager manager)
        {
            this.artist = new Artist();
            this.manager = manager;
            category = new CategoryViewModel(manager);
            categories = new ObservableCollection<CategoryViewModel>();
            this.SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
            this.RemoveCommand = new RelayCommand(o => { });
    }

        public ArtistViewModel(Artist artist, IManager manager)
        {
            this.artist = artist;
            this.manager = manager;
            category = new CategoryViewModel(artist.Category, manager);
            categories = new ObservableCollection<CategoryViewModel>();
            this.SaveCommand = new RelayCommand(o => manager.UpdateArtist(artist));
            this.RemoveCommand = new RelayCommand(o => { });
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

        public string CategoryName
        {
            get { return artist.Category == null ? "" : artist.Category.Label; }
        }

        public CategoryViewModel Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    CategoryVmToCategory(category);
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var artist = obj as ArtistViewModel;

            if (artist == null)
                return false;


            return artist.artist.Equals(this.artist);
        }

        private void LoadCategories()
        {
            categories.Clear();
            var listCategories = manager.GetAllCategories();

            foreach (var category in listCategories)
                categories.Add(new CategoryViewModel(category, manager));

        }

        private void CategoryVmToCategory(CategoryViewModel vm)
        {
            if (vm == null)
                return;

            artist.Category = new Category()
            {
                Id = vm.Identifier,
                Label = vm.Name
            };
        }
    }
}
