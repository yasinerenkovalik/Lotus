using Application.Repository;
using Domain;
using Persistence.Context;
using System.Linq.Expressions;
using Application.Utilities;
using Microsoft.AspNetCore.Http;

namespace Persistence.Respository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly PostgresContext _postgresContext;

        public GenericRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

      

        public string FileUpload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return ("Dosya boş veya eksik.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);

                    byte[] bytes = memoryStream.ToArray();
                    string base64String = Convert.ToBase64String(bytes);

                    return  base64String ;
                }
            }
            catch (Exception ex)
            {
                return ( $"İşlem sırasında bir hata oluştu: {ex.Message}");
            }
        }

        public void Add(T entity)
        {
            
            _postgresContext.Add(entity);
            _postgresContext.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var entity = _postgresContext.Set<T>().Find(id);
            if (entity != null)
            {
                entity.Active = false;
                Update(entity);
                _postgresContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            
            _postgresContext.Update(entity);
            _postgresContext.SaveChanges();
           
        }

        public T Get(int id)
        {
            return _postgresContext.Set<T>().Find(id);

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _postgresContext.Set<T>().ToList();
        }

     
    }
}