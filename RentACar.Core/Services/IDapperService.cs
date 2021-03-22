using RentACar.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Services
{
    public interface IDapperService<TEntity> where TEntity : class
    {
        void Execute(string sql, object param = null);
        Task ExecuteAsync(string sql, object param = null);
        IEnumerable<TEntity> Query(string sql, object param = null);
        Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null);
        TEntity QueryFirst(string sql, object param = null);
        Task<TEntity> QueryFirstAsync(string sql, object param = null);
        TEntity QueryFirstOrDefault(string sql, object param = null);
        Task<TEntity> QueryFirstOrDefaultAsync(string sql, object param = null);
        TEntity QuerySingle(string sql, object param = null);
        Task<TEntity> QuerySingleAsync(string sql, object param = null);
        TEntity QuerySingleOrDefault(string sql, object param = null);
        Task<TEntity> QuerySingleOrDefaultAsync(string sql, object param = null);
    }
}
