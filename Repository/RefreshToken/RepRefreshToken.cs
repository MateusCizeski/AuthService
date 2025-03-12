using Core.Repository;
using Domain;

namespace Repository
{
    public class RepRefreshToken : BaseRepository<RefreshToken>, IRepRefreshToken
    {
        public RepRefreshToken(AppDbContext context) : base(context)
        {
        }
    }
}
