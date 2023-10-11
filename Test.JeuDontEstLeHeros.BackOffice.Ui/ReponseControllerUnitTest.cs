using JeuDontEstLeHeros.BackOffice.Ui.Controllers;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.JeuDontEstLeHeros.BackOffice.Ui
{
    public class ReponseControllerUnitTest
    {
        private readonly HerosDbcontext _dbcontext;


        public ReponseControllerUnitTest()
        {
            // mise en place d'une base de données en mémoire
            _dbcontext = CreateDbContextMemory();

            var data = new List<Reponse>()
            {
                new Reponse() { Id = 0, Proposition = "Lune"},
                new Reponse() { Id = 0, Proposition = "Soleil"},
                new Reponse() { Id = 0, Proposition = "Suède"},
            };

            _dbcontext.Reponses.AddRange(data);
            _dbcontext.SaveChanges();

        }


        #region Test
        [Fact]
        public void TestCreateResponseProblem()
        {

            //Act
            ReponseWorkOfUnit workOfUnit = new(_dbcontext);
            ReponseController controller = new(workOfUnit);

            Reponse ajout = new () { Id = 1, Proposition = "Il existe déjà" };
            var retour = controller.Create(ajout);

            //Assert
            Assert.NotNull(retour);
            Assert.IsType<ObjectResult>(retour);

        }

        [Fact]
        public void TestCreateResponse()
        {

            //Act
            ReponseWorkOfUnit workOfUnit = new(_dbcontext);
            ReponseController controller = new(workOfUnit);

            Reponse ajout = new() { Id = 0, Proposition = "Tout est Ok" };
            var retour = controller.Create(ajout);

            //Assert
            Assert.NotNull(retour);
            Assert.IsType<RedirectToActionResult>(retour);
            
        }
        #endregion

        #region méthode private
        private HerosDbcontext CreateDbContextMemory()
        {
            var builder = new DbContextOptionsBuilder<HerosDbcontext>();
            builder.UseInMemoryDatabase("Reponse_Dev");
            var option = builder.Options;

            return new HerosDbcontext(option);
        }

        #endregion
    }
}