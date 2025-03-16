using Core;
using Domain;
using Infra;

namespace Repository
{
    public class RepRefreshToken : BaseRepository<RefreshToken>, IRepRefreshToken
    {
        public RepRefreshToken(ApplicationDbContext context) : base(context)
        {
        }
    }
}
