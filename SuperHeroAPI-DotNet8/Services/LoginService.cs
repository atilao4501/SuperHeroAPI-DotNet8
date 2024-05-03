using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Services.Interfaces;

namespace SuperHeroAPI_DotNet8.Services;
public class LoginService : ILoginService
{
    DataContext _context;
    IConfiguration _config;

    public LoginService(DataContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }
    
    public string CreateToken(Agency agency)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, agency.Name),
            new Claim(ClaimTypes.Role, agency.Role)
        };

        var key = new SymmetricSecurityKey(
            Convert.FromBase64String(_config.GetSection("Jwt:SigningKey")
                .Value!));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:ValidAudiences"];
        
        var token = new JwtSecurityToken(
            claims: claims,
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}