using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo.DAL.Common
{
    public interface IDatabase
    {
        DbCommand CreateCommand(string commandTxt);
        int DeclareParameter(DbCommand command, string name, DbType type);
        void DefineParameter(DbCommand command, string name, DbType type, object value);
        void DefineOutputParameter(DbCommand command, string name, DbType type);
        void SetParameter(DbCommand command, string name, object value);
        IDataReader ExecuteReader(DbCommand command);
        int ExecuteNonQuery(DbCommand command);
        object ExecuteScalar(DbCommand command);
    }
}
