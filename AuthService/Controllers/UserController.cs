using Application;
using Core.Controller;
using Domain;
using Microsoft.AspNetCore.Components;

namespace AuthService.Controllers
{
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
