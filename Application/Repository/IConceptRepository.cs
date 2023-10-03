using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Repository;

public interface IConceptRepository:IGenericRepository<Concept>
{
    void AddWithImage(Concept entity);
} 