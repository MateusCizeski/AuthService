using Microsoft.AspNetCore.Mvc;

namespace Core
{
    public class BaseController<TEntity, TService> : ControllerBase where TEntity : class where TService : IBaseApplication<TEntity>
    {
        protected readonly TService _service;

        public BaseController(TService service) 
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
    }
}
