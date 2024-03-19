using Application.Utilities;
using Domain;

namespace Application.Repository;

public interface IAdminRepository:IGenericRepository<Admin>
{
    public Result Login(string username,string password);
}