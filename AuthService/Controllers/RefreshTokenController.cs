using Application;
using Core.Controller;
using Domain;

namespace AuthService.Controllers
{
    public class RefreshTokenController : BaseController<RefreshToken, IAplicRefreshToken>
    {
        private readonly IAplicRefreshToken _aplicRefreshToken;

        public RefreshTokenController(IAplicRefreshToken aplicRefreshToken) : base(aplicRefreshToken)
        {
            _aplicRefreshToken = aplicRefreshToken;
        }
    }
}
