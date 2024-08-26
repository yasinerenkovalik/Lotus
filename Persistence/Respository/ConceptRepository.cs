using System.Net;
using Application.Repository;
using Domain;

using Persistence.Context;

namespace Persistence.Respository;

public class ConceptRepository : GenericRepository<Concept>, IConceptRepository
{
    private readonly PostgresContext _postgresContext;
    public ConceptRepository(PostgresContext postgresContext) : base(postgresContext)
    {
        _postgresContext = postgresContext;
    }

    
}

