using Application.Repository;
using Domain;
using Persistence.Context;

namespace Persistence.Respository;

public class ConceptRepository:GenericRepository<Concept>, IConceptRepository
{
    public ConceptRepository(PostgresContext postgresContext) : base(postgresContext)
    {
    }
}