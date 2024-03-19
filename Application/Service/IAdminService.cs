using Application.Utilities;
using Domain;

namespace Application;

public interface IAdminService:IGenericService<Admin>
{
    public IResult Login(string username,string password);
}