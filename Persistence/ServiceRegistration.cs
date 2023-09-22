using Application;
using Application.Repository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Respository;
using Persistence.Services;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<PostgresContext>();
        services.AddScoped<IConceptService, ConceptService>();
        services.AddScoped<IConceptRepository, ConceptRepository>();

    }
}