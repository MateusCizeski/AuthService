using Core;
using Domain;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepUser : BaseRepository<User>, IRepUser
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<User> _dbSet;

        public RepUser(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
