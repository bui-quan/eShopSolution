using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QuanTest.Data.EF
{
    public class QuanTestDbContextFactory : IDesignTimeDbContextFactory<QuanTestDbContext>
    {
        public QuanTestDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("QuanTestConnection");
            var optionsBuilder = new DbContextOptionsBuilder<QuanTestDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QuanTestDbContext(optionsBuilder.Options);
        }
    }
}
