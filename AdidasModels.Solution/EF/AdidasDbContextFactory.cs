using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdidasModels.Solution.EF
{
    public class AdidasDbContextFactory : IDesignTimeDbContextFactory<AdidasDbContext>
    {
        AdidasDbContext IDesignTimeDbContextFactory<AdidasDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AdidasSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<AdidasDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AdidasDbContext(optionsBuilder.Options);
        }
    }
}