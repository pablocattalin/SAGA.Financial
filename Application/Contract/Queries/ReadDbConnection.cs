using System.Data;

namespace Backend.Application.Contract.Contract.Queries
{
    public class ReadDbConnection
    {
        private readonly IDbConnection _connection;

        public ReadDbConnection(IDbConnection connection)
        {

            this._connection = connection;
        }

        public IDbConnection Get() => _connection;
    }

}