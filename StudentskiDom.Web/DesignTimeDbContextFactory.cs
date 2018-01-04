using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentskiDom.Data.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Web
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MojContext>
    {
        public MojContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MojContext>();
            var connectionString = configuration.GetConnectionString("Lokalni");
            builder.UseSqlServer(connectionString);
            return new MojContext(builder.Options);
        }
    }
}
