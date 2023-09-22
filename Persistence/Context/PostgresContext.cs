using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class PostgresContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Lotus;Pooling=true;Connection Lifetime=0;");
    }

    public DbSet<Concept> Concepts { get; set; }
}