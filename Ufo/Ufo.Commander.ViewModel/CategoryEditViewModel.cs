using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ufo.BL;
using Ufo.BL.Interfaces;
using Ufo.Domain;

namespace Ufo.Commander.ViewModel
{
    public class CategoryEditViewModel : ViewModelBase
    {
        #region private members
        private Category category;
        private IManager manager;
        #endregion

        #region ctor
        public CategoryEditViewModel(IManager manager)
        {
            this.manager = manager;
            this.category = new Category();
            this.SaveCommand = new RelayCommand(o => manager.UpdateCategory(category));
            this.RemoveCommand = new RelayCommand(o => manager.RemoveCategory(category), o => manager.CategoryExists(category) == false);
        }

        public CategoryEditViewModel(Category category, IManager manager)
        {
            this.manager = manager;
            this.category = category;
            this.SaveCommand = new RelayCommand(o => manager.UpdateCategory(category));
            this.RemoveCommand = new RelayCommand(o => manager.RemoveCategory(category), o => manager.CategoryExists(category) == false);
        }
        #endregion

        #region properties
        public string Name
        {
            get { return category.Label; }
            set
            {
                if (category.Label != value)
                {
                    category.Label = value;
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
        }

        public string Identifier
        {
            get { return category.Id; }
            set
            {
                if (category.Id != value)
                {
                    category.Id = value;
                    RaisePropertyChangedEvent(nameof(Identifier));
                }
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        #endregion
    }
}
