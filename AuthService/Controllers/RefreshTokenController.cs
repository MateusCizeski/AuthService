using Application;
using Core;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/v1/token")]
    public class RefreshTokenController : BaseController<RefreshToken, IAplicRefreshToken>
    {
        private readonly IAplicRefreshToken _aplicRefreshToken;

        public RefreshTokenController(IAplicRefreshToken aplicRefreshToken) : base(aplicRefreshToken)
        {
            _aplicRefreshToken = aplicRefreshToken;
        }
    }
}
