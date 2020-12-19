using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Utils
{
    public static class JWTUtils
    {
        public static string GenerateJWT(
            IdentityUser user,
            IList<string> roles,
            string jwtKey,
            string jwtIssuer
            )
        {
            //Hash Security Key Object from the JWT Key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate list of claims with general and universally recommended claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            //Generate final token adding Issuer and Subscriber data, claims, expriation time and Key
            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtIssuer,
                claims,
                null,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
            );

            //Return token string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
