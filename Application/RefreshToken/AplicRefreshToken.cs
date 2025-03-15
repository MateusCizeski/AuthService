using Core.Application;
using Domain;

namespace Application
{
    public class AplicRefreshToken : BaseApplication<RefreshToken>, IAplicRefreshToken
    {
        private readonly IServRefreshToken _servRefreshToken;

        public AplicRefreshToken(ServRefreshToken servRefreshToken) : base(servRefreshToken)
        {
            _servRefreshToken = servRefreshToken;
        }
    }
}
