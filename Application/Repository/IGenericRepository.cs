using System.Linq.Expressions;
using Application.Utilities;
using Domain;

namespace Application.Repository;

public interface IGenericRepository<T> where T:BaseEntity
{
    IResult Add(T entity);
    IResult Delete(int id);
    IResult Update(T entity);
    IDataResult<T> Get(int id);
    IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);

}