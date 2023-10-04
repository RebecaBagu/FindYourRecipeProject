using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindYourRecipe.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;

namespace PizzaApp.Application.Helpers;

public class JwtHelper
{
    public static string GenerateToken(User user, string secretKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };

        var claimIdentity = new ClaimsIdentity(claims);

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = claimIdentity,
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}
