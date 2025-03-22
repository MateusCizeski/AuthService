using Core;
using Domain;
using Infra;
using Microsoft.AspNetCore.Identity;
using Repository;

namespace Application
{
    public class AplicUser : BaseApplication<User>, IAplicUser
    {
        #region Ctor
        private readonly IRepUser _repUser;
        private readonly IMapperUser _mapperUser;
        private readonly JwtService _jwtService;

        public AplicUser(IRepUser repUser, IMapperUser mapperUSer, JwtService jwtService) : base(repUser)
        {
            _repUser = repUser;
            _mapperUser = mapperUSer;
            _jwtService = jwtService;
        }
        #endregion

        #region Create
        public void Create(CreateUserDTO dto)
        {
            var user = _mapperUser.MapperCreate(dto);

            var hashPassword = PasswordHasher.HashPassword(user.Password);

            user.Password = hashPassword;

            _repUser.CreateUser(user);
        }
        #endregion

        #region Session
        public ReturnSessionDTO Session(SessionUserDTO dto)
        {
            var user = _repUser.GetUser(dto);
            var hasher = new PasswordHasher<object>();
            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Senha incorreta.");
            }

            var token = _jwtService.GenerateToken(user.Name);

            return _mapperUser.MapperReturnSession(user, token);
        }
        #endregion

        #region Edit
        public void Edit(Guid id, EditUserDTO dto)
        {
            var user = _repUser.UserById(id);

            _mapperUser.MapperEditing(user, dto);
            _repUser.EditUser(user);
        }
        #endregion

        public DetailUserDTO DetailUser(Guid id)
        {
            var user = _repUser.UserById(id);

            return _mapperUser.MapperDetailUser(user);
        }
    }
}
