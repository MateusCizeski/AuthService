using Core;
using Domain;
using Infra;
using Repository;

namespace Application
{
    public class AplicUser : BaseApplication<User>, IAplicUser
    {
        private readonly IRepUser _repUser;
        private readonly IMapperUser _mapperUser;

        public AplicUser(IRepUser repUser, IMapperUser mapperUSer) : base(repUser)
        {
            _repUser = repUser;
            _mapperUser = mapperUSer;
        }

        public void AddAsync(CreateUserDTO dto)
        {
            var user = _mapperUser.Novo(dto);

            var hashPassword = PasswordHasher.HashPassword(user.Password);

            user.Password = hashPassword;
            _repUser.AddAsync(user);
        }
    }
}
