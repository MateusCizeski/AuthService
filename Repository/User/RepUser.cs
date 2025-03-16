using Core;
using Domain;
using Infra;

namespace Repository
{
    public class RepUser : BaseRepository<User>, IRepUser
    {
        public RepUser(ApplicationDbContext context) : base(context)
        {
        }
    }
}
