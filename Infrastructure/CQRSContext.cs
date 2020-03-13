using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure
{
    public class CQRSContext : DbContext
    {

        #region Constructors

        public CQRSContext(DbContextOptions<CQRSContext> options) : base(options)
        {
        }

        #endregion

        #region Db Sets

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            builder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CQRSContext>
        {
            public CQRSContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Directory.GetCurrentDirectory() + "/../CQRS Example/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<CQRSContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new CQRSContext(builder.Options);
            }
        }

    }
}
