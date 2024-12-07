using BulkyBookModels.Model;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookDataAccess.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Category Table
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Products Table
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        ///  Extend User
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        /// <summary>
        /// AffiliatePostRequest Table
        /// </summary>
        public DbSet<AffiliatePostRequest> AffiliatePostRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
             //SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
            new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Name = "Company", ConcurrencyStamp = "2", NormalizedName = "Docter" },
            new IdentityRole() { Name = "Student", ConcurrencyStamp = "3", NormalizedName = "Student" }
                );
        }
    }
}
