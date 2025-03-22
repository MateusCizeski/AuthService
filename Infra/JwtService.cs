using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra
{
    public class JwtService
    {
        private readonly SymmetricSecurityKey _securityKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expireMinutes;

        public JwtService(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var secretKey = configuration["Jwt:Key"] ?? throw new Exception("Chave JWT não encontrada.");

            Console.WriteLine($"Chave JWT lida: {secretKey}");

            try
            {
                byte[] keyBytes = Convert.FromBase64String(secretKey.Trim());
                _securityKey = new SymmetricSecurityKey(keyBytes);
                Console.WriteLine("Chave decodificada como Base64 com sucesso.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Falha ao decodificar Base64. Usando chave como texto puro.");
                _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            }

            _issuer = configuration["Jwt:Issuer"] ?? throw new Exception("Issuer não configurado.");
            _audience = configuration["Jwt:Audience"] ?? throw new Exception("Audience não configurado.");
            _expireMinutes = configuration.GetValue<int>("Jwt:ExpirationMinutes");
        }

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}