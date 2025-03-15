using Core.Repository;

namespace Core.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task AddAsync(T entity) => await _repository.AddAsync(entity);

        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
