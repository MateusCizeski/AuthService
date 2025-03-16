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
    }
}
