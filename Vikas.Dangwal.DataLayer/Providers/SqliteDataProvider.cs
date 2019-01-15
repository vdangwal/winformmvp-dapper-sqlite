using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vikas.Dangwal.Interface;
using Dapper;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.SQLite;
using System.Data.SQLite.Generic;
using System.Data;
using System.Composition;

namespace Vikas.Dangwal.DataLayer.Providers
{
    
    public class SqliteDataProvider<T> : IDataProvider<T> where T : class
    {
        private readonly SQLiteConnectionStringBuilder _builder;
        public SqliteDataProvider(string connectionString)
        {
            _builder = new SQLiteConnectionStringBuilder(connectionString);
        }

        public async Task<IEnumerable<T>> Get(string query, CommandType queryType, params object[] parameters)
        {
            using (var connection = SQLiteFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = _builder.ConnectionString;
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(query, param: parameters, commandType: queryType);
            }
        }

        public async Task<T> GetSingle(string query, CommandType queryType, params object[] parameters)
        {
            using (var connection = SQLiteFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = _builder.ConnectionString;
                await connection.OpenAsync();
                return await connection.QuerySingleAsync<T>(query, param: parameters, commandType: queryType);
            }
        }
    }
}
