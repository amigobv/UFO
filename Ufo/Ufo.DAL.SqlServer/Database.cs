﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufo.DAL.Common;

namespace Ufo.DAL.SqlServer
{
    public class Database : IDatabase
    {
        private string connectionString;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbCommand CreateCommand(string commandTxt)
        {
            return new SqlCommand(commandTxt);
        }

        public int DeclareParameter(DbCommand command, string name, DbType type)
        {
            if (!command.Parameters.Contains(name))
            {
                return command.Parameters.Add(new SqlParameter(name, type));
            }

           throw new ArgumentException($"Parameter {name} is already defined");
        }

        public void DefineParameter(DbCommand command, string name, DbType type, object value)
        {
            int index = DeclareParameter(command, name, type);
            command.Parameters[index].Value = value;
        }

        public void DefineOutputParameter(DbCommand command, string name, DbType type)
        {
            int index = DeclareParameter(command, name, type);
            command.Parameters[index].Direction = ParameterDirection.Output;
        }

        public void SetParameter(DbCommand command, string name, object value)
        {
            if (command.Parameters.Contains(name))
            {
                command.Parameters[name].Value = value;
                return;
            }

            throw new ArgumentException($"Parameter {name} does not exist.");
        }

        public IDataReader ExecuteReader(DbCommand command)
        {
            DbConnection connection = null;

            try
            {
                connection = CreateDbConnection();
                command.Connection = connection;

                var behavior = IsSharedConnection() ? CommandBehavior.Default : CommandBehavior.CloseConnection;

                return command.ExecuteReader(behavior);
            }
            catch(Exception)
            {
                ReleaseConnection(connection);
                throw;
            }
        }

        public int ExecuteNonQuery(DbCommand command)
        {
            DbConnection connection = null;

            try
            {
                connection = CreateDbConnection();
                command.Connection = connection;

                return command.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        public object ExecuteScalar(DbCommand command)
        {
            DbConnection connection = null;

            try
            {
                connection = CreateDbConnection();
                command.Connection = connection;

                return command.ExecuteScalar();
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        private DbConnection CreateDbConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        private void ReleaseConnection(DbConnection connection)
        {
            connection.Close();
        }

        private bool IsSharedConnection()
        {
            return false;
        }
    }
}
