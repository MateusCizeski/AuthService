using Core;
using Domain;

namespace Application
{
    public interface IAplicUser : IBaseApplication<User>
    {
        void Create(CreateUserDTO dto);
        ReturnSessionDTO Session(SessionUserDTO dto);
        void Edit(Guid id, EditUserDTO dto);
        DetailUserDTO DetailUser(Guid id);
    }
}
