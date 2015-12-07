using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common.Domain;

namespace Ufo.Commander.Model
{
    public class CategoryModel
    {
        private Category category;

        #region ctor
        public CategoryModel()
        {
            category = new Category();
        }

        public CategoryModel(Category category)
        {
            this.category = category;
        }
        #endregion

        public Category GetInstance()
        {
            return category;
        }


        public string Label
        {
            get { return category.Label; }
            set { category.Label = value; }
        }
    }
}
