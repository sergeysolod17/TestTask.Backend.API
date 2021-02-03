using System;
using Microsoft.EntityFrameworkCore;
using Backend.API.DataDesign.DataSeed;
using Backend.API.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Backend.API.DataDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("app.settings.json")
                        .Build();
            string ConnectionString = configuration["ConnectionStrings:TestDatabase"];

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var options = optionsBuilder.UseSqlServer(ConnectionString).Options;
            using(var context = new DataContext(options))
            {
                DataSeedOrchestrator dataSeedOrchestrator = new DataSeedOrchestrator(context);
                dataSeedOrchestrator.ApplyAll();
            }
            
            Console.WriteLine("All data were uploaded to MS SQL Server");
        }
    }
}