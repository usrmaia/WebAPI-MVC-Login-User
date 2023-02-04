using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Configurations
{
    public class JwtService : IAuthenticationServiceConfiguration
    {
        public JwtService()
        {
        }

        public string GetToken(User userOutput)
        {
            var secret = Encoding.ASCII.GetBytes("minha-chave-secreta-dadgalidayfalifafail");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userOutput.Id.ToString()),
                    new Claim(ClaimTypes.Name, userOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userOutput.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}