using JeuDontEstLeHeros.Core.Application.DTO;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Models;
using JeuDontEstLeHeros.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Test.JeuDontEstLeHeros.Infrastructure;

namespace Test.JeuDontEstLeHeros
{
    public class AventureControllerUnitTest
    {
        private readonly HerosDbcontext _dbcontext;

        public AventureControllerUnitTest ()
        {
            _dbcontext = TestHeroDbContextMemory.CreateDbContextMemory();
            _dbcontext.Aventures.Add(new Aventure() { Nom = "L'attaque des titans", Id = 1, Description = "Des titans attaquent les capitales du monde entier." });
            _dbcontext.Aventures.Add(new Aventure() { Nom = "L'espoir", Id = 2, Description = "Après la défaite des nains, l'espoir renait après la naissance du nouveau héros." });

            _dbcontext.SaveChanges();
        }

        #region méthode de test
        [Fact]
        public void TestListAventureController()
        {
            AventureController controller = new(_dbcontext);
            var result = controller.Index();

            // Asset
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var value = (result as ViewResult)?.Model as List<AventureDTO>;
            Assert.NotNull(value);
            Assert.IsType<List<AventureDTO>>(value);
            Assert.True(value.Count == 2);

        }

        [Fact]
        public void TestCreateAventureControllerIsOk()
        {
            AventureController controller = new(_dbcontext);
            AventureDTO aventure = new()
            {
                Id = 0,
                Nom = "Voici la nouvelle aventure",
                Description = "une aventure pour tout le monde.",
                DateCreation = DateTime.Now,
            };
            var result = controller.Create(aventure);

            // test -- si tout va bien
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);

        }

        [Fact]
        public void TestCreateAventureControllerIsNoOk()
        {
            AventureController controller = new(_dbcontext);
            AventureDTO aventure = new()
            {
                Id = 1,
                Nom = "Voici la nouvelle aventure",
                Description = "une aventure pour tout le monde.",
                DateCreation = DateTime.Now,
            };
            var result = controller.Create(aventure);

            // test -- si tout va bien
            Assert.NotNull(result);
            Assert.IsNotType<RedirectToActionResult>(result);
            Assert.IsType<ViewResult>(result);

            var value = (result as ViewResult)?.Model as AventureDTO;
            Assert.NotNull(value);
            Assert.Equal(1, value.Id);
        }
        #endregion


    }
}