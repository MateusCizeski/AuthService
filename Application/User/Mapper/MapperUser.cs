using Domain;

namespace Application
{
    public class MapperUser : IMapperUser
    {
        public User Novo(CreateUserDTO dto)
        {
            var user = new User();

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.EmailConfirmed = false;
            
            return user;
        }
    }
}
