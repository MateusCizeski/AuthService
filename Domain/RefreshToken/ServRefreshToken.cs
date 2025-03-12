using Core.Repository;
using Core.Service;

namespace Domain
{
    public class ServRefreshToken : BaseService<RefreshToken>, IServRefreshToken
    {
        private readonly IRepRefreshToken _repRefreshToken;
        public ServRefreshToken(IRepRefreshToken repository) : base(repository)
        {
            _repRefreshToken = repository;
        }
    }
}
