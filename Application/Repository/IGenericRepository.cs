using System.Linq.Expressions;
using Application.Utilities;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Repository;

public interface IGenericRepository<T> where T:BaseEntity
{
    void Add(T entity);
    void Delete(int id);
    void Update(T entity);
    T Get(int id);
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
   
     string FileUpload(IFormFile file);

}