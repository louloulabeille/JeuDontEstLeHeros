using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.Database
{
    public class HerosIdentityContextFactory : IDesignTimeDbContextFactory<HerosIdentityDbContext>
    {

        public HerosIdentityDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Database=IdentityHeros;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;";
            var optionsBuilder = new DbContextOptionsBuilder<HerosIdentityDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HerosIdentityDbContext(optionsBuilder.Options);
        }
    }
}
