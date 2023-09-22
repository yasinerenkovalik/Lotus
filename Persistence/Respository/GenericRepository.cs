using Application.Repository;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Utilities;

namespace Persistence.Respository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly PostgresContext _postgresContext;

        public GenericRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public IResult Add(T entity)
        {
            _postgresContext.Add(entity);
            _postgresContext.SaveChanges();
            return new  SuccesResult();

        }

        public IResult Delete(int id)
        {
            var entity = _postgresContext.Set<T>().Find(id);
            if (entity != null)
            {
                _postgresContext.Remove(entity);
                _postgresContext.SaveChanges();
                return new SuccesResult();
            }

            return new ErrorResult();
        }

        public IResult Update(T entity)
        {
            if (entity == null)
            {
                return new ErrorResult();
            }

            _postgresContext.Update(entity);
            _postgresContext.SaveChanges();
            return new SuccesResult();
        }

        public IDataResult<T> Get(int id)
        {
           var result= _postgresContext.Set<T>().Find(id);
           
           return new SuccessDataResult<T>(result);

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
           var result=  filter == null ? _postgresContext.Set<T>().ToList() :
                _postgresContext.Set<T>().Where(filter).ToList();
           
           Console.WriteLine(result);
           return result;

        }

    }
}