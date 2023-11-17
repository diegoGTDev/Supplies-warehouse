using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebService.Data;
using WebService.Models.Response;
using WebService.Requests;
using WebService.Tools;
using System.Security.Claims;
using WebService.Models;
using WebService.Models.Common;
using Microsoft.Extensions.Options;

namespace WebService.Services
{
    public class UserService : iUserService
    {

        private readonly AppConfiguration _configuration;

        public UserService(IOptions<AppConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public UserResponse Auth(AuthRequest authRequest)
        {
            UserResponse userresponse = new UserResponse();
            using (var db = new db_warehouseContext())
            {
                string spassword = Encrypt.GetSHA256(authRequest.Password);
                var usuario = db.Accounts.Where(d => d.Name == authRequest.Username && d.Password == spassword).FirstOrDefault();

                if (usuario == null) { return null; }
                userresponse.UserName = usuario.Name;
                userresponse.Role = usuario.Role;
                userresponse.Token = this.GetToken(usuario);
            }
            return userresponse;
        }
        private string GetToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var uKey = Encoding.ASCII.GetBytes(this._configuration.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this._configuration.Issuer,
                Audience = this._configuration.Audience,
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, account.AccId.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, account.Name)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(uKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
