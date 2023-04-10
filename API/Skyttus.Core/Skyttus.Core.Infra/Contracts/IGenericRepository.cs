using InfiGrowth.Models.Models;
using System.Linq.Expressions;

namespace Skyttus.Core.Infra.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IQueryable<T>> GetAll(bool trackChanges = false);

        Task<IQueryable<T>> GetAll(int pageNumber, int pageSize, bool trackChanges = false);

        Task<T?> GetById(Guid id, bool trackChanges = false);

        Task<T> Add(T entity);

        Task<List<T>> AddMultiple(List<T> entities);

        Task<T> Update(T entity);

        Task<bool> Delete(Guid id);

        Task<SearchResult<T>> Search(Expression<Func<T, bool>> criteria, Expression<Func<T, Object>> orderBy);
    }
}
