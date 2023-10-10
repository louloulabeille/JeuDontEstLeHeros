using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.Database
{
    internal class HerosContextFactory : IDesignTimeDbContextFactory<HerosDbcontext>
    {
        public HerosDbcontext CreateDbContext(string[] args)
        {
            string connectionString = string.Empty;
            /*IConfigurationBuilder builder = new ConfigurationBuilder();
            DirectoryInfo? info = Directory.GetParent(Directory.GetCurrentDirectory());

            if (info != null)
            {
                builder.SetBasePath(Path.Combine(info.FullName, "JeuDontEstLeHeros.UI"));
                builder.AddJsonFile("appsettings.json");
                IConfigurationRoot root = builder.Build();
                connectionString = root.GetConnectionString("Heros")?? string.Empty;

            }*/
            connectionString = "Server=localhost;Database=Heros;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;";
            var optionsBuilder = new DbContextOptionsBuilder<HerosDbcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HerosDbcontext(optionsBuilder.Options);
        }
    }
}
