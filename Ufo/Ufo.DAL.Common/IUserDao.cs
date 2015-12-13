using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.Domain;

namespace Ufo.DAL.Common
{
    public interface IUserDao
    {
        int Count();

        IList<User> FindAll();

        User FindById(string id);

        bool Insert(User o);

        bool Update(User o);

        bool Delete(string id);
    }
}
