using Core.Repository;
using Domain;

namespace Repository
{
    public class RepUser : BaseRepository<User>, IRepUser
    {
        public RepUser(AppDbContext context) : base(context)
        {
        }
    }
}
