using Application;
using Application.Repository;
using Application.Utilities;
using Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace Persistence.Services;

public class AdminService:IAdminService
{
    private readonly IAdminRepository _adminRepository;
    
    public AdminService(IAdminRepository adminRepository)
    {
        
        _adminRepository = adminRepository;
    }
    public IResult Add(Admin entity)
    {
        if (entity.UserName.Length==0)
        {
            return new ErrorResult("Kullanıcı Adi Boş Olamaz");
        }

        _adminRepository.Add(entity);
         return new SuccesResult("Admin başarıyla eklendi");
    }

    public IResult Delete(int id)
    {
        if (id > 0)
        {
            _adminRepository.Delete(id);
            return new SuccesResult("Admin Silindi");
        }

        return new ErrorResult("Admin Silinemedi");
    }

    public IResult Update(Admin entity)
    {
        _adminRepository.Update(entity);
        return new SuccesResult("Admin Bilgileri Güncellendi");
    }

    public IDataResult<Admin> Get(int id)
    {
        if (_adminRepository.Get(id).UserName.Length <= 0)
        {
            return new ErrorDataResult<Admin>("Admin Listesi Boş");
        }
        
        
        return new SuccessDataResult<Admin>();
    }

    public IDataResult<List<Admin>> GetAll()
    {
        var result=  _adminRepository.GetAll(e => e.Active ==true);
        return  new SuccessDataResult<List<Admin>>(result);
    }

    public IResult Login(string username,string password)
    {
        var result = _adminRepository.Login(username, password);
        if (result.Success==false)
        {
            return new ErrorResult("Kullanıcı bulunamadı");
        }

        return new SuccesResult(result.Message);
    }
}