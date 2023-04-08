using Products.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Products.Persistence.Repositories;
using Products.Application.Services;
using Products.Persistence.Auth;

namespace Products.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProductConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IBrancheRepository), typeof(BrancheRepository));
            services.AddScoped(typeof(IEmployeRepository), typeof(EmployeRepository));
            services.AddScoped(typeof(ISizeRepository), typeof(SizeRepository));

           // services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
          
                return services;
        }
    }

}
