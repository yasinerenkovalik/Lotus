using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application;
using Application.Utilities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LotusApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost("add")]
        public Result Add(Admin admin)
        {
            var result = _adminService.Add(admin);
            if (result.Success==false)
            {
               
                return new ErrorResult(result.Message);
            }

            return new SuccesResult(result.Message);

        }
        [HttpDelete("delete")]
        public Result Delete(int id)
        {
            var result = _adminService.Delete(id);
            if (result.Success==false)
            {
                
                return new ErrorResult(result.Message);
            }
            return new SuccesResult(result.Message);
           

        }
        [HttpPut("update")]
        public Result Update(Admin admin)
        {
            var result = _adminService.Update(admin);
            if (result.Success==false)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccesResult(result.Message);
           

        }
        [AllowAnonymous]
        [HttpGet("getall")]
        public IDataResult<List<Admin>> GetAll()
        {
            IDataResult<List<Admin>> result = _adminService.GetAll();
            
            return  result;
        }
        [AllowAnonymous]
       [HttpGet("login")]
        public Result Login(string username,string password)
        {
            var result = _adminService.Login(username, password);
            if (result.Success==false)
            {
                return new ErrorResult();
            }
            return new SuccesResult(result.Message);
        } 
        [AllowAnonymous]

        [HttpGet("tokenvalidation")]
        public bool ValitationToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bubenimsigninkeyim"));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler. ValidateToken(token,new TokenValidationParameters(){
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        }, out SecurityToken validatedToken);
                        var jwtToken = (JwtSecurityToken)validatedToken;
                        return true;

            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
