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

        public User GetUser(SessionUserDTO dto)
        {
            var user = _context.Users.Where(u => u.Email == dto.Email).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("Email/Password incorrect.");
            }

            return user;
        }

        public User UserById(Guid id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("user not exists.");
            }

            return user;
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
