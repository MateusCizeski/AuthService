using Core.Repository;
using Core.Service;

namespace Domain
{
    public class ServUser : BaseService<User>, IServUser
    {
        private readonly IRepUser _repUser;
        public ServUser(IRepUser repository) : base(repository)
        {
            _repUser = repository;
        }
    }
}
