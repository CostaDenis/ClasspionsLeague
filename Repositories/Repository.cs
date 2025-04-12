using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace ClasspionsLeague.Repositories
{

    public class Repository<T> where T : class
    {
        public Repository(SqlConnection connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public IEnumerable<T> Get()
            => _connection.GetAll<T>();

        public T Get(Guid id)
            => _connection.Get<T>(id);

        public void Create(T model)
            => _connection.Insert<T>(model);

        public void Update(T model)
            => _connection.Update<T>(model);

        public void Delete(T model)
            => _connection.Delete<T>(model);

        public void Delete(Guid id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }

    }
}