using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Repository;
using Application.Utilities;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Persistence.Respository;

public class AdminRepository:GenericRepository<Admin>,IAdminRepository
{
    private readonly IConfiguration _configuration;
    private readonly PostgresContext _postgresContext;
    
    public AdminRepository(PostgresContext postgresContext,IConfiguration configuration) : base(postgresContext)
    {
        _postgresContext = postgresContext;
        _configuration = configuration;
    }
    public Result Login(string email, string password)
    {
        var login=  _postgresContext.Set<Admin>().FirstOrDefault(n => n.UserName == email && n.Password == password);
        Debug.Assert(login != null, nameof(login) + " != null");
        if (login.Active==false  )
        {
            return new ErrorResult("Kullanıcı Bulunamadı");
        } 
        var result= Jwt(login.Id);

        return new SuccesResult(result);
    }
    
    public string? Jwt(int id)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.NameId,id.ToString()),
        };
         
        var singninKey = _configuration["jwt:SingingKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(singninKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
          

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["jwt:Issure"],
            audience: _configuration["jwt:Audience"],
            claims:claims,
            expires:DateTime.Now.AddDays(15),
            notBefore:DateTime.Now,
            signingCredentials:credentials
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
           
       
        return token;
    }
}