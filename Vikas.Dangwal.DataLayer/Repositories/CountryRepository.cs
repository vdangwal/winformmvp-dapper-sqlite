using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vikas.Dangwal.DataLayer.Providers;
using Vikas.Dangwal.Interface;
using Vikas.Dangwal.Interface.Repository;
using Vikas.Dangwal.Model.Gdp;

namespace Vikas.Dangwal.DataLayer.Repositories
{
    public class CountryRepository : IRepository<Country, string>
    {
        private readonly IDataProvider<Country> _dataProvider;
        public CountryRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            _dataProvider = new SqliteDataProvider<Country>(connectionString);
        }
        public void Add(Country entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> Find(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Country> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _dataProvider.Get("SELECT * FROM Country ORDER BY CountryCode ", System.Data.CommandType.Text, null);
        }

        public void Remove(Country entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }
    }
}
