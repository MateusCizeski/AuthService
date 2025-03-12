using Core.Repository;
using Core.Service;

namespace Core.Application
{
    public class BaseApplication<T> : IBaseRepository<T> where T : class
    {
        private readonly IBaseService<T> _baseService;

        public BaseApplication(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        public Task AddAsync(T entity)
        {
           return _baseService.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            return _baseService.DeleteAsync(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _baseService.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return _baseService.GetByIdAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            return _baseService.UpdateAsync(entity);
        }
    }
}
