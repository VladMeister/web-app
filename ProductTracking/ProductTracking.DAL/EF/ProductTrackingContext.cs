using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.Entities;

namespace ProductTracking.DAL.EF
{
    public class ProductTrackingContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RealizationPlace> RealizationPlaces { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ProductTrackingContext(DbContextOptions<ProductTrackingContext> options) : base(options)
        {
            Database.Migrate();
        }

        public ProductTrackingContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.ProductType).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Weight).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Calority).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.CreationDate).IsRequired();


            modelBuilder.Entity<Product>().Property(e => e.Name).HasMaxLength(50);


            modelBuilder.Entity<Company>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.Country).IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.City).IsRequired();

            modelBuilder.Entity<Company>().Property(c => c.Registered).IsRequired();

            modelBuilder.Entity<Company>().HasIndex(c => c.Name).IsUnique();


            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<City>().Property(c => c.DeliveryWay).IsRequired();


            modelBuilder.Entity<RealizationPlace>().Property(r => r.Name).IsRequired();

            modelBuilder.Entity<RealizationPlace>().Property(r => r.WorkTime).IsRequired();

            modelBuilder.Entity<RealizationPlace>().HasIndex(r => r.Name).IsUnique();


            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();


            modelBuilder.Entity<User>().Property(u => u.Login).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();


            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();


            modelBuilder.Entity<User>().Property(u => u.Login).HasMaxLength(30);

            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(50);


            Role adminRole = new Role { Id = 1, Name = "admin" };
            Role userRole = new Role { Id = 2, Name = "user" };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });


            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Login = "meister",
                    Password = "25D55AD283AA400AF464C76D713C07AD",
                    RoleId = adminRole.Id
                }
                );

            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Grodno",
                    DeliveryWay = DeliveryWay.Car
                },
                new City()
                {
                    Id = 2,
                    Name = "Stockholm",
                    DeliveryWay = DeliveryWay.Plane
                },
                new City()
                {
                    Id = 3,
                    Name = "New York",
                    DeliveryWay = DeliveryWay.Plane
                }
                );

            modelBuilder.Entity<RealizationPlace>().HasData(
                new RealizationPlace()
                {
                    Id = 1,
                    Name = "Almi",
                    WorkTime = 11,
                    CityId = 1
                },
                new RealizationPlace()
                {
                    Id = 2,
                    Name = "Euroopt",
                    WorkTime = 10,
                    CityId = 1
                },
                new RealizationPlace()
                {
                    Id = 3,
                    Name = "Walmart",
                    WorkTime = 8,
                    CityId = 3
                },
                new RealizationPlace()
                {
                    Id = 4,
                    Name = "Auchan",
                    WorkTime = 9,
                    CityId = 2
                },
                new RealizationPlace()
                {
                    Id = 5,
                    Name = "Green",
                    WorkTime = 10,
                    CityId = 1
                }
                );

            modelBuilder.Entity<Company>().HasData(
               new Company()
               {
                   Id = 1,
                   Name = "MilkWorld",
                   Country = "Belarus",
                   City = "Grodno",
                   Registered = true
               },
               new Company()
               {
                   Id = 2,
                   Name = "StockFood",
                   Country = "Sweden",
                   City = "Malmo",
                   Registered = true
               },
               new Company()
               {
                   Id = 3,
                   Name = "EaterCorp",
                   Country = "USA",
                   City = "Tucson",
                   Registered = true
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
