namespace Core
{
    public class BaseApplication<T> : IBaseRepository<T> where T : class
    {
        private readonly IBaseRepository<T> _baseService;

        public BaseApplication(IBaseRepository<T> baseService)
        {
            _baseService = baseService;
        }

        public Task AddAsync(T entity)
        {
           return _baseService.AddAsync(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            return _baseService.DeleteAsync(id);
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
