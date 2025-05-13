using AgriEnergyConnect.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public ApplicationDbContext()
    {
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Product> Products { get; set; }

=======
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AgriEnergyConnect
{
    // Inherit from IdentityDbContext to include Identity tables like AspNetUsers
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your custom tables
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    // Used by EF Core CLI tools at design-time to build the DbContext
>>>>>>> 006fc78 (css)
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

<<<<<<< HEAD
            var connectionString = configuration.GetConnectionString("DefaultConnection"); 

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString); // Or your database provider
=======
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
>>>>>>> 006fc78 (css)

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
