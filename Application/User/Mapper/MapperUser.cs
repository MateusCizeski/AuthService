using Domain;

namespace Application
{
    public class MapperUser : IMapperUser
    {
        public User MapperCreate(CreateUserDTO dto)
        {
            var user = new User();

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.EmailConfirmed = false;
            
            return user;
        }

        public void MapperEditing(User user, EditUserDTO dto)
        {
            user.Name = dto.Name;
        }

        public ReturnSessionDTO MapperReturnSession(User user, string token)
        {
            return new ReturnSessionDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                token = token
            };
        }

        public DetailUserDTO MapperDetailUser(User user)
        {
            return new DetailUserDTO
            {
                Id= user.Id,
                Name = user.Name,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
            };
        }
    }
}
