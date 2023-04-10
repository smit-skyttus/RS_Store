using AutoMapper;
using Skyttus.Core.Entity.Contracts;
using Skyttus.Core.Infra.Contracts;
using Skyttus.Core.Services.Contracts;

namespace Skyttus.Core.Services.Services
{
    public abstract class BaseService<T, Q> : IBaseService<T, Q> where T : class
                                            where Q : class, IBaseEntity
    {
        protected readonly IGenericRepository<Q> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(IGenericRepository<Q> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<IEnumerable<T>> GetAll(bool trackChanges = false)
        {
            var result = await _repository.GetAll(trackChanges);

            //var entities = result.ToListAsync();

            var models = _mapper.Map<IEnumerable<T>>(result);

            return models;
        }

        public async virtual Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize, bool trackChanges = false)
        {
            var result = await _repository.GetAll(pageNumber, pageSize, trackChanges);

            //var entities = result.ToListAsync();

            var models = _mapper.Map<IEnumerable<T>>(result);

            return models;
        }

        public async virtual Task<T> GetById(Guid id, bool trackChanges = false)
        {
            var entity = await _repository.GetById(id);

            var model = _mapper.Map<T>(entity);

            return model;
        }

        public async virtual Task<T> Add(T model)
        {
            var entity = _mapper.Map<Q>(model);

            var result = await _repository.Add(entity);

            var response = _mapper.Map<T>(result);

            return response;
        }

        public async virtual Task<dynamic> Add<R>(T model)
        {
            var entity = _mapper.Map<Q>(model);

            var result = await _repository.Add(entity);

            if (typeof(R) is IBaseEntity)
            {
                var response = _mapper.Map<T>(result);
                return response;
            }
            else
            {
                return entity.Id;
            }
        }

        public async virtual Task<List<T>> AddMultiple(List<T> models)
        {
            var entities = _mapper.Map<List<Q>>(models);

            var results = await _repository.AddMultiple(entities);

            var response = _mapper.Map<List<T>>(results);

            return response;
        }

        public async virtual Task<T> Update(T model)
        {
            var entity = _mapper.Map<Q>(model);

            var result = await _repository.Update(entity);

            var response = _mapper.Map<T>(result);

            return response;
        }

        public async virtual Task<dynamic> Update<R>(T model)
        {
            var entity = _mapper.Map<Q>(model);

            var result = await _repository.Update(entity);

            if (typeof(R) is IBaseEntity)
            {
                var response = _mapper.Map<T>(result);
                return response;
            }
            else
            {
                return entity.Id;
            }
        }

        public async virtual Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
