using InfiGrowth.Models.Models;
using Microsoft.EntityFrameworkCore;
using Skyttus.Core.Entity.Contracts;
using Skyttus.Core.Infra.Contracts;
using System.Linq.Expressions;

namespace Skyttus.Core.Infra.Repository
{
    public abstract class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class, IBaseEntity
    {
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context) : base(context)
           => (_dbSet) = (context.Set<T>());

        public async virtual Task<IQueryable<T>> GetAll(bool trackChanges = false)
        {
            return
                 trackChanges ?
                 await Task.FromResult(_dbSet) :
                 await Task.FromResult(_dbSet.AsNoTracking());
        }

        public async virtual Task<IQueryable<T>> GetAll(int pageNumber, int pageSize, bool trackChanges = false)
        {
            var pageNo = pageNumber - 1;
            return
                 trackChanges ?
                 await Task.FromResult(_dbSet.Skip(pageNo * pageSize).Take(pageSize)) :
                 await Task.FromResult(_dbSet.Skip(pageNo * pageSize).Take(pageSize).AsNoTracking());
        }

        public async virtual Task<T?> GetById(Guid id, bool trackChanges = false)
        {
            if (trackChanges)
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async virtual Task<T> Add(T entity)
        {
            var result = await Task.FromResult(_dbSet.Add(entity));
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task<T> Update(T entity)
        {
            var result = await Task.FromResult(_dbSet.Update(entity));
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<SearchResult<T>> Search(Expression<Func<T, bool>> criteria, Expression<Func<T, Object>>? orderBy = null)
        {
            IEnumerable<T>? results = null;
            if (orderBy != null)
            {
                results = await _dbSet.Where(criteria).OrderBy(orderBy).AsNoTracking().ToListAsync();
            }
            else
            {
                results = await _dbSet.Where(criteria).AsNoTracking().ToListAsync();
            }

            return new SearchResult<T>()
            {
                Results = results
            };
        }

        public async Task<SearchResult<T>> Search(int pageNumber, int pageSize, Expression<Func<T, bool>> criteria, Expression<Func<T, Object>>? orderBy = null)
        {
            var pageNo = pageNumber - 1;
            IEnumerable<T> results;
            int totalRecords = await _dbSet.CountAsync();
            if (orderBy != null)
            {
                results = await _dbSet.Where(criteria).OrderBy(orderBy).AsNoTracking().Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                results = await _dbSet.Where(criteria).AsNoTracking().Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
            }

            return new SearchResult<T>()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                Results = results
            };
        }

        public async virtual Task<List<T>> AddMultiple(List<T> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
    }
}
