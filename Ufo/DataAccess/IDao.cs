using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DomainClass;

namespace DataAccess
{
    interface IDao
    {
        int GetSize();
        IDomain Get(int id);
        void Store(IDomain domainObj);
        void Update(IDomain domainObj);
        void Delete(int id);
    }
}
