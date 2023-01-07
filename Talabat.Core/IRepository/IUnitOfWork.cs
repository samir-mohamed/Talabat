using System;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
