using Core;
using Domain;
using Repository;

namespace Application
{
    public class AplicRefreshToken : BaseApplication<RefreshToken>, IAplicRefreshToken
    {
        private readonly IRepRefreshToken _repRefreshToken;

        public AplicRefreshToken(IRepRefreshToken repRefreshToken) : base(repRefreshToken)
        {
            _repRefreshToken = repRefreshToken;
        }
    }
}
