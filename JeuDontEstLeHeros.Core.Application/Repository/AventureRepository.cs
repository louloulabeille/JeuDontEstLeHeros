using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Infrastructure.DataLayer;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.Repository
{
    /// <summary>
    /// class Repository de Aventure
    /// </summary>
    public class AventureRepository : IAventureRepository
    {
        private readonly IAventureDataLayer _dataLayer;

        public AventureRepository(HerosDbcontext dbcontext)
        {
            _dataLayer = new AventureDataLayer(dbcontext);
        }

        public void Add(Aventure aventure)
        {
            _dataLayer.Add(aventure);
        }

        public IEnumerable<Aventure> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Aventure? GetAventureById(int id)
        {
            return _dataLayer.GetById(id);
        }

        public void Remove(Aventure aventure)
        {
            _dataLayer.Remove(aventure);
        }

        public void Update(Aventure aventure)
        {
            _dataLayer.Update(aventure);
        }
    }
}
