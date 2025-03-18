using Core;
using Domain;

namespace Repository
{
    public interface IRepUser : IBaseRepository<User>
    {
        void CreateUser(User user);
    }
}
