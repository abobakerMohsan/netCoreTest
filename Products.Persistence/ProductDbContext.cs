using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;
using Products.Domain.Common;
using Products.Domain.Entites;
using Products.Common;

namespace Products.Persistence
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public ProductDbContext(
            DbContextOptions<ProductDbContext> options, 
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }


        public DbSet<Branche> Branches { get; set; }
        public DbSet<Employe> Employes { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<MainSize> MainSizes { get; set; }
        public DbSet<SizeProduct> SizeProduct { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }
    }
}
