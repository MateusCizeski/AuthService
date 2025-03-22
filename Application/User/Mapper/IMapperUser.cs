using Domain;

namespace Application
{
    public interface IMapperUser
    {
        User MapperCreate(CreateUserDTO dto);
        ReturnSessionDTO MapperReturnSession(User user, string token);
        void MapperEditing(User user, EditUserDTO dto);
        DetailUserDTO MapperDetailUser(User user);
    }
}
