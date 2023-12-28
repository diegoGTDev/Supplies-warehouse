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
using Microsoft.AspNetCore.Authorization;

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
            Console.WriteLine("Request is: ", authRequest.Username);
            UserResponse userresponse = new UserResponse();
            using (var db = new db_warehouseContext())
            {
                string spassword = Encrypt.GetSHA256(authRequest.Password);
                // var usuario = db.Accounts.Where(d => d.Name == authRequest.Username && d.Password == spassword).FirstOrDefault();
                
                var usuario = db.Accounts.Where(
                    d => d.Name == authRequest.Username && d.Password == spassword).SelectMany(

                    u => db.Roles.Where(
                          r => u.Role == r.RoleId)
                          .SelectMany(
                            d => db.Departments.Where(
                                d => u.Department == d.DepartmentId)
                                .Select(t1 => new User
                                {
                                    Id = u.AccId,
                                    Name = u.Name,
                                    Role = d.Name,
                                    Department = t1.Name
                                }))).FirstOrDefault();

                if (usuario == null) { return null; }
                userresponse.UserName = usuario.Name;
                Console.WriteLine("Usuario ROL: " + usuario.Role);
                Console.WriteLine("Usuario DEP: " + usuario.Department);
                userresponse.Role = usuario.Role;
                userresponse.Token = this.GetToken(usuario);
                userresponse.Department = usuario.Department;
        
            }
            return userresponse;
        }

        //Create a function to verify the token
        [Authorize]
        public bool VerifyToken(string token)
        {
            Console.WriteLine("Verifying Token in process");
            var tokenHandler = new JwtSecurityTokenHandler();
            var uKey = Encoding.ASCII.GetBytes(this._configuration.SecretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(uKey),
                    ValidateIssuer = true,
                    ValidIssuer = this._configuration.Issuer,
                    ValidateAudience = true,
                    ValidAudience = this._configuration.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private string GetToken(iUser account)
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
                        new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                        new Claim(ClaimTypes.Name, account.Name.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("Department", account.Department.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(uKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
