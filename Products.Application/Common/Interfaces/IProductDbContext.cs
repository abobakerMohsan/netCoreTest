using Microsoft.EntityFrameworkCore;
using Products.Domain.Entites;
using Products.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
      


         DbSet<Branche> Branches { get; set; }
         DbSet<Employe> Employes { get; set; }

         DbSet<Product> Products { get; set; }
         DbSet<MainSize> MainSizes { get; set; }
         DbSet<SizeProduct> SizeProduct { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
