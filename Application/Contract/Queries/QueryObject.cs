using System.Data;
using System.Text.Json;
using Dapper;

namespace Backend.Application.Contract.Contract.Queries
{

    public class QueryObject
    {
        private readonly IDbConnection _connection;

        public QueryObject(ReadDbConnection connection)
        {
            this._connection = connection.Get();
        }

        public async Task<JsonDocument> RawQueryAsync(string query, object arguments = null)
        {

            return await RawQueryAsync(query, false, true, arguments)
                            .ConfigureAwait(false);
        }

        public async Task<JsonDocument> RawQueryAsync(string query, bool arrayWrapper = false, bool auto = true, object arguments = null)
        {
            var wrapper = arrayWrapper ? string.Empty : ", WITHOUT_ARRAY_WRAPPER";

            var mode = auto ? "AUTO" : "PATH";

            var nullValues = ", INCLUDE_NULL_VALUES";

            var result = await this._connection.QueryAsync<string>($"{query} FOR JSON {mode} {wrapper} {nullValues}", arguments)
                        .ConfigureAwait(false);

            var jsonBuild = string.Concat(result.DefaultIfEmpty(arrayWrapper ? "[]" : "{}"));

            return JsonDocument.Parse(jsonBuild);
        }

        public async Task<IEnumerable<T>> GetCollection<T>(string query, object arguments = null)
        {
            var Collection = await this._connection.QueryAsync<T>($"{query}", arguments).ConfigureAwait(false);

            return Collection;            

        }

        public async Task<T> GetObject<T>(string query, object arguments = null)
        {
            var collection = await GetCollection<T>(query, arguments)
                                     .ConfigureAwait(false);

            return collection.SingleOrDefault();
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, object arguments = null)
        {
            return await _connection.ExecuteScalarAsync<T>(query, arguments);
        }

        public async Task ExecuteAsync(string query, object argument = null)
        {
            await _connection.ExecuteAsync(query, argument);
        }
    }
}
