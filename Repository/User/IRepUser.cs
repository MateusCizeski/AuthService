using Core;
using Domain;

namespace Repository
{
    public interface IRepUser : IBaseRepository<User>
    {
        void CreateUser(User user);
        User GetUser(SessionUserDTO dto);
        User UserById(Guid id);
        void EditUser(User user);
    }
}
