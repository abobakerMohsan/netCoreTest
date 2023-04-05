using Products.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using Products.Domain.Entities;
using Products.Application.Services;

namespace Products.Persistence
{
    public class ProductDbContext : DbContext
    {

        IAuthService _authService;
        public ProductDbContext(DbContextOptions<ProductDbContext> options, IAuthService authService)
           : base(options)
        {
            _authService = authService;

        }

        public DbSet<Branche> Branches { get; set; }
        public DbSet<Employe> Employes { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeProduct> SizeProduct { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var brancheGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var employeGuid = Guid.Parse("{86786087-8003-43C1-92A4-87876A7C5DDE}");
            var postGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var sizeGuid = Guid.NewGuid();
            var sizeProductGuid = Guid.NewGuid();


        

            var passwordHash = _authService.ComputeSha256Hash("123456");

            var user = new User("Abobaker Mohsan ", "ab@gmail.com", passwordHash, "admin");


            int userId = user.Id;

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<Branche>().HasData(new Branche
            {
                Id = brancheGuid,
                Name = "Yemen",
                Description = "Yemen Branche",
                Country = "Yemen",
                City = "Sana`a",
                Region = "Yemen",
                PostalCode = "1999",
            });

            modelBuilder.Entity<Employe>().HasData(new Employe
            {
                Id = employeGuid,
                BranchesId = employeGuid,
                UserId = userId,
                FullName = "Abobaker Mohsan ",
                Phone = "772544010",
                Address = "Yemen",
       

    });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                Id = sizeGuid,
                Name = "Small",
                Description = "Small Size Product",

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = postGuid,
                Name = "Malk",
                Description = "Lorem ipsum dolor sit amet, consectetur",
            });

            modelBuilder.Entity<SizeProduct>().HasData(new SizeProduct
            {
                Id = sizeProductGuid,
                ProductId = postGuid,
                SizeId = sizeGuid,
                SizePrice=200,
             });
                   

        

        }
    }

}
