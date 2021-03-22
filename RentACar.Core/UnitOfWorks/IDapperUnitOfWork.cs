using System;
using System.Data;

namespace RentACar.Core.UnitOfWorks
{
    public interface IDapperUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IsolationLevel IsolationLevel { get; }
        void Commit();
    }
}
