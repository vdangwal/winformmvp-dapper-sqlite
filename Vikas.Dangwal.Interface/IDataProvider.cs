using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Vikas.Dangwal.Interface
{
    public interface IDataProvider<T> where T: class
    {
        Task<T> GetSingle(string query, CommandType queryType, params object[] parameters);
        Task<IEnumerable<T>> Get(string query, CommandType queryType, params object[] parameters);
    }
}
