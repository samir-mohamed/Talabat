using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.ISpecification;

namespace Talabat.Core.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllWithSpecification(ISpecification<T> specification);
        Task<T> GetByIdWithSpecification(ISpecification<T> specification);
        Task<int> GetCountAsync(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
