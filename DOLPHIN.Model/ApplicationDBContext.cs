using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Model
{
    public class ApplicationDBContext : DbContext, IDbContext
    {
        private readonly bool isMemoryDatabase;
        public ApplicationDBContext(IConfiguration configurations, bool isMemoryDatabase = false)
        {
            this.Configs = configurations;
            this.isMemoryDatabase = isMemoryDatabase;
        }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }
        protected IConfiguration Configs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.isMemoryDatabase)
            {
                return;
            }

            if (!optionsBuilder.IsConfigured && this.Configs != null)
            {
                optionsBuilder.UseMySql(string.IsNullOrEmpty(this.Configs["ConnectionStrings:VSECConnection"]) ? this.Configs.GetConnectionString("VSECConnection") : this.Configs["ConnectionStrings:VSECConnection"]);

                // optionsBuilder.UseSecondLevelCache();
            }
            //optionsBuilder
            //    .UseMySql("server=localhost;database=dolphin;user=root;password=;sslmode=none;")
            //    .UseLoggerFactory(LoggerFactory.Create(b => b
            //    .AddFilter(level => level >= LogLevel.Information)))
            //    .EnableSensitiveDataLogging()
            //    .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleUser>()
                .HasKey(c => new { c.RoleId, c.UserId });
            modelBuilder.Entity<OrderDetails>()
                .HasKey(c => new { c.OrderId, c.ProductId });
            modelBuilder.Entity<RolePermission>()
                .HasKey(c => new { c.RoleId, c.PermissionId });
            modelBuilder.Entity<Comments>()
                .HasKey(c => new { c.UserId, c.ProductId });
            modelBuilder.Entity<Users>()
                .HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Users>()
                .HasIndex(c => c.UserName).IsUnique();
            modelBuilder.Entity<ProductOption>()
                .HasKey(c => new { c.ProductId, c.OptionId });
        }
    }
}
