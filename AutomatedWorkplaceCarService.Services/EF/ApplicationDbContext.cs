using AutomatedWorkplaceCarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutomatedWorkplaceCarService.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Role> defaultRoles = new List<Role>()
            {
                new Role(){ Id = 1, Name = "admin"},
                new Role(){ Id = 2, Name = "client"},
                new Role(){ Id = 3, Name = "employee"}
            };

            List<Post> defaultPosts = new List<Post>()
            {
                new Post(){ Id = 1, Name = "Администратор"},
                new Post(){ Id = 2, Name = "Автомеханик"},
                new Post(){ Id = 3,Name = "Автоэлектрик"},
                new Post(){ Id = 4, Name = "Автодиагност"},
                new Post(){ Id = 5, Name = "Автомаляр"}
            };
            Employee admin = new Employee()
            {
                Id = 1,
                Name = "Иван", Surname = "Иванов", Patronymic = "Иванович",
                Login = "admin", Password = "123",
                RoleId = 1, PostId = 1
            };
            modelBuilder.Entity<Post>().HasData(defaultPosts);
            modelBuilder.Entity<Role>().HasData(defaultRoles);
            modelBuilder.Entity<Employee>().HasData(admin);
        }
    }
}
