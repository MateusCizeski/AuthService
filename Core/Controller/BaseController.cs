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

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
        {
            if (entity == null) return BadRequest();

            await _service.AddAsync(entity);

            return Ok();
        }

        [HttpPut]
        public virtual async Task<ActionResult> Update([FromBody] TEntity entity)
        {
            if (entity == null) return BadRequest();

            await _service.UpdateAsync(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
