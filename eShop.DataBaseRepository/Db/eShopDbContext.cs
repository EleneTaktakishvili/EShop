using eShop.DataBaseRepository.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace eShop.DataBaseRepository.Db
{
   public class eShopDbContext :DBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();


                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


            }
        }
    }
}
