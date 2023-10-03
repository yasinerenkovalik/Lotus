using System.Net.Sockets;
using Application.Utilities;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application;

public interface IGenericService<T> 
{
    IResult Add(T entity);
    IResult Delete(int id);
    IResult Update(T entity);
    IDataResult<T> Get(int id);
    IDataResult<List<T>> GetAll();
  

}