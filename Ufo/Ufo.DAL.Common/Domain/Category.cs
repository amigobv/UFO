using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common.Domain
{
    public class Category
    {
        #region Properties
        public string Id { get; set; } 
        public string Label { get; set; }
        #endregion

        public Category(string id, string label)
        {
            Id = id;
            Label = label;
        }

        public override string ToString()
        {
            return "Category: " + Label + "(" + Id + ")";
        }
    }
}
