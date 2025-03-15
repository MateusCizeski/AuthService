using Core.Application;
using Domain;

namespace Application
{
    public class AplicUser : BaseApplication<User>, IAplicUser
    {
        private readonly IServUser _servUser;

        public AplicUser(ServUser servUser) : base(servUser)
        {
            _servUser = servUser;
        }
    }
}
