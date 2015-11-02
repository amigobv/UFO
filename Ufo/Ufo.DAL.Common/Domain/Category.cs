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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(Object o)
        {
            var obj = o as Category;

            if (obj != null)
            {
                return Id.Equals(obj.Id) && Label.Equals(obj.Label);
            }

            return false;
        }

        public override string ToString()
        {
            return "Category: " + Label + "(" + Id + ")";
        }
    }
}
