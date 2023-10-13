using JeuDontEstLeHeros.Core.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Test.JeuDontEstLeHeros.Infrastructure
{
    public static class TestHeroDbContextMemory
    {
        #region méthode private
        public static HerosDbcontext CreateDbContextMemory()
        {
            var builder = new DbContextOptionsBuilder<HerosDbcontext>();
            builder.UseInMemoryDatabase("Reponse_Dev");
            var option = builder.Options;

            return new HerosDbcontext(option);
        }

        #endregion
    }
}