using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.DatabseContext;

public class ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> stu) : DbContext(stu)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationsDbContext).Assembly);
    }
}
