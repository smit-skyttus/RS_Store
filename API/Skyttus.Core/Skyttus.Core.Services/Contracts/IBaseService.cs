using Skyttus.Core.Entity.Contracts;

namespace Skyttus.Core.Services.Contracts
{
    public interface IBaseService<T, Q> where T : class
                                        where Q : class, IBaseEntity
    {
        Task<IEnumerable<T>> GetAll(bool trackChanges);
        Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize, bool trackChanges);
        Task<T> GetById(Guid id, bool trackChanges = false);
        Task<T> Add(T model);
        Task<dynamic> Add<R>(T model);
        Task<T> Update(T model);
        Task<dynamic> Update<R>(T model);
        Task<bool> Delete(Guid id);
        Task<List<T>> AddMultiple(List<T> entities);
    }
}
