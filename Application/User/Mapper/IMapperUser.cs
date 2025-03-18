using Domain;

namespace Application
{
    public interface IMapperUser
    {
        User Novo(CreateUserDTO dto);
    }
}
