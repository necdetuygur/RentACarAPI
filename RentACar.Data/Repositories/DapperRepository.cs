using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RentACar.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Data.Repositories
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {

        private readonly IConfiguration _configuration;
        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Execute(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                connection.Execute(sql, param);
            }
        }

        public async Task ExecuteAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(sql, param);
            }
        }

        public IEnumerable<TEntity> Query(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                return connection.Query<TEntity>(sql, param);
            }
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TEntity>(sql, param);
            }
        }

        public TEntity QueryFirst(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                return connection.QueryFirst<TEntity>(sql, param);
            }
        }

        public async Task<TEntity> QueryFirstAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstAsync<TEntity>(sql, param);
            }
        }

        public TEntity QueryFirstOrDefault(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<TEntity>(sql, param);
            }
        }

        public async Task<TEntity> QueryFirstOrDefaultAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param);
            }
        }

        public TEntity QuerySingle(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                return connection.QuerySingle<TEntity>(sql, param);
            }
        }

        public async Task<TEntity> QuerySingleAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleAsync<TEntity>(sql, param);
            }
        }

        public TEntity QuerySingleOrDefault(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<TEntity>(sql, param);
            }
        }

        public async Task<TEntity> QuerySingleOrDefaultAsync(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnectionString")))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<TEntity>(sql, param);
            }
        }
    }
}
