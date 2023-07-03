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
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Application> Applications { get; set; }

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
                new Post(){ Id = 3, Name = "Автоэлектрик"},
                new Post(){ Id = 4, Name = "Автодиагност"},
                new Post(){ Id = 5, Name = "Механик моторист-дизелист"},
                new Post(){ Id = 6, Name = "Автосварщик"}
            };
            List<Brand> defaultBrands = new List<Brand>()
            {
                new Brand(){ Id = 1, Name = "Mercedes"},
                new Brand(){ Id = 2, Name = "BMW"},
                new Brand(){ Id = 3, Name = "Audi"},
                new Brand(){ Id = 4, Name = "Volvo"}
            };
            List<Model> defaultModels = new List<Model>()
            {
                new Model(){ Id = 1, BrandId = 1, Name = "A-class"},
                new Model(){ Id = 2, BrandId = 1, Name = "C-class"},
                new Model(){ Id = 3, BrandId = 1, Name = "E-class"},
                new Model(){ Id = 4, BrandId = 2, Name = "M3"},
                new Model(){ Id = 5, BrandId = 2, Name = "M4"},
                new Model(){ Id = 6, BrandId = 2, Name = "M5"},
                new Model(){ Id = 7, BrandId = 3, Name = "A3"},
                new Model(){ Id = 8, BrandId = 3, Name = "A4"},
                new Model(){ Id = 9, BrandId = 3, Name = "A5"},
                new Model(){ Id = 10, BrandId = 4, Name = "S60"},
                new Model(){ Id = 11, BrandId = 4, Name = "S90"},
                new Model(){ Id = 12, BrandId = 4, Name = "V60"},
                new Model(){ Id = 13, BrandId = 4, Name = "V90"}
            };
            List<Transmission> defaultTransmissions = new List<Transmission>()
            {
                new Transmission(){ Id = 1, Name = "Автоматическая"},
                new Transmission(){ Id = 2, Name = "Механическая"},
                new Transmission(){ Id = 3, Name = "Вариативная"}
            };
            List<Service> defaultServices = new List<Service>()
            {
                new Service(){ Id = 1, Name = "Техническое обслуживание"},
                new Service(){ Id = 2, Name = "Ремонт двигателя"},
                new Service(){ Id = 3, Name = "Ремонт системы охлаждения"},
                new Service(){ Id = 4, Name = "Ремонт трансмиссии"},
                new Service(){ Id = 5, Name = "Ремонт подвески"},
                new Service(){ Id = 6, Name = "Ремонт рулевого"},
                new Service(){ Id = 7, Name = "Кузовной ремонт"},
                new Service(){ Id = 8, Name = "Шиномонтаж"},
                new Service(){ Id = 9, Name = "Ремонт автоэлектрики"},
                new Service(){ Id = 10, Name = "Диагностика"}
            };
            List<Specialization> defaultSpecializations = new List<Specialization>()
            {
                new Specialization(){ Id = 1, PostId = 2, ServiceId = 2},
                new Specialization(){ Id = 2, PostId = 3, ServiceId = 3},
                new Specialization(){ Id = 3, PostId = 6, ServiceId = 4},
                new Specialization(){ Id = 4, PostId = 6, ServiceId = 5},
                new Specialization(){ Id = 5, PostId = 2, ServiceId = 6},
                new Specialization(){ Id = 6, PostId = 5, ServiceId = 7},
                new Specialization(){ Id = 7, PostId = 2, ServiceId = 8},
                new Specialization(){ Id = 8, PostId = 3, ServiceId = 9},
                new Specialization(){ Id = 9, PostId = 4, ServiceId = 10},
                new Specialization(){ Id = 10, PostId = 4, ServiceId = 1}
            };
            List<Stage> defaultStages = new List<Stage>()
            {
                new Stage(){ Id = 1, Name = "Оценивание работы"},
                new Stage(){ Id = 2, Name = "Подтверждение клиентом"},
                new Stage(){ Id = 3, Name = "Выполнение работы"},
                new Stage(){ Id = 4, Name = "Работы завершины"}
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
            modelBuilder.Entity<Brand>().HasData(defaultBrands);
            modelBuilder.Entity<Model>().HasData(defaultModels);
            modelBuilder.Entity<Transmission>().HasData(defaultTransmissions);
            modelBuilder.Entity<Service>().HasData(defaultServices);
            modelBuilder.Entity<Specialization>().HasData(defaultSpecializations);
            modelBuilder.Entity<Stage>().HasData(defaultStages);
            modelBuilder.Entity<Employee>().HasData(admin);
        }
    }
}
