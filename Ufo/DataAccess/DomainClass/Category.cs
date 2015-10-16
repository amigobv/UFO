using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DomainClass
{
    class Category : IDomain
    {
        #region Properties
        public int Id { get; set; } 
        public string Label { get; set; }
        public string Identifier { get; set; }
        #endregion

        public Category(int id, string label, string identifier) : base(id)
        {
            Id = id;
            Label = label;
            Identifier = identifier;
        }

        public override string ToString()
        {
            return "Category: " + Label + "(" + Identifier + ")";
        }
    }
}
