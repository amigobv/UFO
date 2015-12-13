using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class CategoriesViewModel : ViewModelBase
    {

        #region private members
        private IManager manager;
        private ObservableCollection<CategoryEditViewModel> categories;
        private CategoryEditViewModel currentCategory;
        #endregion

        #region ctor
        public CategoriesViewModel(IManager manager)
        {
            this.manager = manager;
            Categories = new ObservableCollection<CategoryEditViewModel>();
            currentCategory = new CategoryEditViewModel(new Category(), manager);
            LoadCategories();
        }
        #endregion

        #region properties
        public ObservableCollection<CategoryEditViewModel> Categories
        {
            get { return categories; }
            set
            {
                if (categories != value)
                {
                    categories = value;
                    RaisePropertyChangedEvent(nameof(Categories));
                }
            }
        }

        public CategoryEditViewModel CurrentCategory
        {
            get { return currentCategory; }
            set
            {
                if (currentCategory != value)
                {
                    currentCategory = value;
                    RaisePropertyChangedEvent(nameof(CurrentCategory));
                }
            }
        }


        #endregion

        public void LoadCategories()
        {
            Categories.Clear();
            var categoriesList = manager.GetAllCategories();

            foreach(var category in categoriesList)
            {
                Categories.Add(new CategoryEditViewModel(category, manager));
            }
        }


    }
}
