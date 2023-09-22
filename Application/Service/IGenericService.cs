using System.Net.Sockets;
using Application.Utilities;
using Domain;

namespace Application;

public interface IGenericService<T> where T:BaseEntity
{
    IResult Add(T entity);
    IResult Delete(int id);
    IResult Update(T entity);
    IDataResult<T> Get(int id);
    IDataResult<List<T>> GetAll();
    
}