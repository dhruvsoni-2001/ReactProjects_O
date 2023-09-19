using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;

namespace BoilerPlate.DbConnector
{
    public class DatabaseExecutor
    {
        private readonly IConfiguration configuration;

        public DatabaseExecutor(IConfiguration config)
        {
            configuration = config;
        }

        private IDbConnection GetConnection()
        {
            var connection = configuration.GetSection("DatabaseType").Value;
            switch (connection.ToLower())
            {
                case "mysql":
                    return new MySqlConnection(configuration.GetConnectionString("MySQLConnection"));
                default:
                    return new SqlConnection(configuration.GetConnectionString("MSSQLConnection"));
            }
        }
        private string GetInsertedIdQuery()
        {
            var connection = configuration.GetSection("DatabaseType").Value;
            switch (connection.ToLower())
            {
                case "mysql":
                    return "select LAST_INSERT_ID()";
                default:
                    return "SELECT CAST(SCOPE_IDENTITY() as int)";
            }
        }

        public IEnumerable<T> Get<T>(string query)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<T>(query);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            var selectExpression = ReflectionHelper.GetSelectAllStatement<T>();
            using (var connection = GetConnection())
            {
                return connection.Query<T>(selectExpression);
            }
        }

        public T GetScaler<T>(string query)
        {
            using (var connection = GetConnection())
            {
                return connection.ExecuteScalar<T>(query);
            }
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string query)
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<T>(query);
            }
        }

        public T GetById<T>(object idValue)
        {
            var selectExpression = idValue.GetSelectStatement<T>();
            using (var connection = GetConnection())
            {
                return connection.QuerySingle<T>(selectExpression.Item1, selectExpression.Item2);
            }
        }

        public async Task<T> GetByIdAsync<T>(object idValue)
        {
            var selectExpression = idValue.GetSelectStatement<T>();
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleAsync<T>(selectExpression.Item1, selectExpression.Item2);
            }
        }

        public int Create<T>(T value)
        {
            var createExpression = value.GetCreateStatement();

            using (var connection = GetConnection())
            {
                var id = connection.QuerySingle<int>(createExpression.Item1 + " " + GetInsertedIdQuery(), createExpression.Item2);
                return id;
            }
        }

        public async Task<int> CreateAsync<T>(T value)
        {
            var createExpression = value.GetCreateStatement();

            using (var connection = GetConnection())
            {
                var id = await connection.QuerySingleAsync<int>(createExpression.Item1 + " " + GetInsertedIdQuery(), createExpression.Item2);
                return id;
            }
        }

        public bool Update<T>(T value)
        {
            var updateExpression = value.GetUpdateStatement();

            using (var connection = GetConnection())
            {
                connection.Execute(updateExpression.Item1, updateExpression.Item2);
                return true;
            }
        }

        public async Task<bool> UpdateAsync<T>(T value)
        {
            var updateExpression = value.GetUpdateStatement();

            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(updateExpression.Item1, updateExpression.Item2);
                return true;
            }
        }

        public bool Delete<T>(object value)
        {
            var existingData = GetById<T>(value);
            if (existingData == null)
            {
                throw new Exception("Requested entity does not exist!");
            }
            var deleteExpression = value.GetDeleteStatement<T>();
            using (var connection = GetConnection())
            {
                connection.Execute(deleteExpression.Item1, deleteExpression.Item2);
                return true;
            }
        }

        public bool Delete(string query)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(query, null);
                return true;
            }
        }

        public async Task<bool> DeleteAsync<T>(object value)
        {
            var deleteExpression = value.GetDeleteStatement<T>();
            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(deleteExpression.Item1, deleteExpression.Item2);
                return true;
            }
        }
    }
}
