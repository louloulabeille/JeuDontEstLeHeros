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
    /// classe utilisé au niveau de l'application pour accéder aux données
    /// </summary>
    public class ReponseRepository : IReponseRepository
    {
        private readonly IReponseDataLayer _dataLayer;

        public ReponseRepository (HerosDbcontext dbcontext)
        {
            _dataLayer = new ReponseDataLayer(dbcontext);
        }
        
        public void Add(Reponse reponse)
        {
            _dataLayer.Add(reponse);
        }

        public Reponse? GetReponseById(int id)
        {
            return _dataLayer.GetById(id);
        }

        public void Remove(Reponse reponse)
        {
            _dataLayer.Remove(reponse);
        }

        public IEnumerable<Reponse> ReponseByDesc(int nbReponse = 10)   // par défaut 10
        {
            return _dataLayer.ReponseByDesc(nbReponse);
        }
    }
}
