using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Domain.Common;
using OnlineShop.Core.Domain.Entities;
using OnlineShop.Infrastructure.Persistence.Config;

namespace OnlineShop.Infrastructure.Persistence.Context;
public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Category { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (ChangeTracker.Entries().Any(x => typeof(BaseAuditableEntity).IsAssignableFrom(x.GetType())))
        {
            var insertedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .Cast<BaseAuditableEntity>().ToList();

            foreach (var item in insertedEntities)
            {
                item.CreatedOn = DateTime.Now;
                item.CreatedBy = 1;
            }

            var updatedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<BaseAuditableEntity>().ToList();

            foreach (var item in updatedEntities)
            {
                item.ModifiedOn = DateTime.Now;
                item.ModifiedBy = 1;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}


//public class ApplicationDbContrextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContrext>
//{
//    public ApplicationDbContrext CreateDbContext(string[] args)
//    {
//        string connnectionString = "Data Source=172.31.31.8;Initial Catalog=OnlineShop;Integrated Security=True;TrustServerCertificate=True;";
//        var options = new DbContextOptionsBuilder<ApplicationDbContrext>().UseSqlServer(connnectionString).Options;

//        return new ApplicationDbContrext(options);
//    }
//}


