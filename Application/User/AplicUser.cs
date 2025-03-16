using Core;
using Domain;
using Repository;

namespace Application
{
    public class AplicUser : BaseApplication<User>, IAplicUser
    {
        private readonly IRepUser _repUser;

        public AplicUser(IRepUser repUser) : base(repUser)
        {
            _repUser = repUser;
        }
    }
}
