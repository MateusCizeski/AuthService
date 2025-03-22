using Application;
using Core;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : BaseController<User, IAplicUser>
    {
        private readonly IAplicUser _aplicUser;

        public UserController(IAplicUser aplicUser) : base(aplicUser) 
        {
            _aplicUser = aplicUser;
        }

        #region Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] CreateUserDTO dto)
        {
            try
            {
                _aplicUser.Create(dto);

                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Session
        [HttpPost]
        [Route("Session")]
        public ActionResult Session([FromBody] SessionUserDTO dto)
        {
            try
            {
                var retorno = _aplicUser.Session(dto);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Edit
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit([FromRoute] Guid id, [FromBody] EditUserDTO dto)
        {
            try
            {
                _aplicUser.Edit(id, dto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        [HttpPut]
        [Route("DetailUser/{id}")]
        public ActionResult DetailUser(Guid id)
        {
            try
            {
                _aplicUser.DetailUser(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
