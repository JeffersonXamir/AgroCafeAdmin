using AgroCafeAdmin.Core.Models.Seguridad;
using AgroCafeAdmin.Data.Repository.Seguridad;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AgroCafeAdmin.Service.Seguridad
{
    public class TokenService : ITokenService
    {
        private readonly IAutorizacionRepository _autorizacionRepository;

        public TokenService(IAutorizacionRepository autorizacionRepository)
        {
            _autorizacionRepository = autorizacionRepository;
        }

        public string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Cedula)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_autorizacionRepository.GetApiToken()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = creds,
                Expires = DateTime.Now.AddDays(1),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
