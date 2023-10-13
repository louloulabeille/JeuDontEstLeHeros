using JeuDontEstLeHeros.BackOffice.Ui.Controllers;
using JeuDontEstLeHeros.Core.Application.WorkOfUnit;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.JeuDontEstLeHeros.Infrastructure;

namespace Test.JeuDontEstLeHeros.BackOffice.Ui
{
    public class ReponseControllerUnitTest
    {
        private readonly HerosDbcontext _dbcontext;

        public ReponseControllerUnitTest()
        {
            // mise en place d'une base de donn�es en m�moire
            _dbcontext = TestHeroDbContextMemory.CreateDbContextMemory();

            var data = new List<Reponse>()
            {
                new Reponse() { Id = 0, Proposition = "Lune"},
                new Reponse() { Id = 0, Proposition = "Soleil"},
                new Reponse() { Id = 0, Proposition = "Su�de"},
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

            Reponse ajout = new () { Id = 1, Proposition = "Il existe d�j�" };
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

    }
}