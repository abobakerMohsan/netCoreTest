using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Common.Interfaces;
using Products.Application.Contracts.Persistence;
using Products.Persistence.Repositories;

namespace Products.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProductConnectionString")));

            services.AddScoped<IProductDbContext>(provider => provider.GetService<ProductDbContext>());

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IBrancheRepository), typeof(BrancheRepository));
            services.AddScoped(typeof(IEmployeRepository), typeof(EmployeRepository));
            services.AddScoped(typeof(ISizeRepository), typeof(SizeRepository));

           // services.AddScoped(typeof(IUserRepository), typeof(UserRepository));


            return services;
        }
    }
}
