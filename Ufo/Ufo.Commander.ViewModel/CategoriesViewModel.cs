﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.BL.Interfaces;
using Ufo.Commander.ViewModel.Basic;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class CategoriesViewModel : ViewModelBase
    {

        #region private members
        private IManager manager;
        private ObservableCollection<CategoryViewModel> categories;
        private CategoryViewModel currentCategory;
        #endregion

        #region ctor
        public CategoriesViewModel(IManager manager)
        {
            this.manager = manager;
            Categories = new ObservableCollection<CategoryViewModel>();
            currentCategory = new CategoryViewModel(new Category(), manager);
            currentCategory.NotifyUpdate += () => LoadCategories();
        }
        #endregion

        #region properties
        public ObservableCollection<CategoryViewModel> Categories
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

        public CategoryViewModel CurrentCategory
        {
            get
            {
                //LoadCategories();
                return currentCategory;
            }
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
            categories.Clear();
            var categoriesList = manager.GetAllCategories();

            foreach(var category in categoriesList)
            {
                categories.Add(new CategoryViewModel(category, manager));
            }

            Categories = categories;
        }


    }
}
