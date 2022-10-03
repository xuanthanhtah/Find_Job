using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.EF
{
    public class FindJobDBContextFactory : IDesignTimeDbContextFactory<FindJobDBContext>
    {
        public FindJobDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("FindJobDb");

            var optionsBuilder = new DbContextOptionsBuilder<FindJobDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FindJobDBContext(optionsBuilder.Options);
        }
    }
}
