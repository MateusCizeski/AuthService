using Core;
using Domain;
using Infra;
using Microsoft.AspNetCore.Identity;
using Repository;

namespace Application
{
    public class AplicUser : BaseApplication<User>, IAplicUser
    {
        private readonly IRepUser _repUser;
        private readonly IMapperUser _mapperUser;
        private readonly JwtService _jwtService;

        public AplicUser(IRepUser repUser, IMapperUser mapperUSer, JwtService jwtService) : base(repUser)
        {
            _repUser = repUser;
            _mapperUser = mapperUSer;
            _jwtService = jwtService;
        }

        public void AddAsync(CreateUserDTO dto)
        {
            var user = _mapperUser.Novo(dto);

            var hashPassword = PasswordHasher.HashPassword(user.Password);

            user.Password = hashPassword;

            _repUser.CreateUser(user);
        }

        public ReturnSessionDTO Session(SessionUserDTO dto)
        {
            var user = _repUser.GetUser(dto);
            var hasher = new PasswordHasher<object>();
            var passwordMatch = hasher.VerifyHashedPassword(null, user.Password, dto.Password);

            if (passwordMatch != PasswordVerificationResult.Success)
            {
                throw new Exception("Senha incorreta.");
            }

            var token = _jwtService.GenerateJwtToken(user.Name);

            return new ReturnSessionDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                token = token
            };
        }
    }
}
