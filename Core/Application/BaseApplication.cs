namespace Core
{
    public class BaseApplication<T> : IBaseRepository<T> where T : class
    {
        private readonly IBaseRepository<T> _baseService;

        public BaseApplication(IBaseRepository<T> baseService)
        {
            _baseService = baseService;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _baseService.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return _baseService.GetByIdAsync(id);
        }
    }
}
