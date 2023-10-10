using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Repository
{
    /// <summary>
    /// interface du repository Reponse
    /// </summary>
    public interface IReponseRepository
    {
        public IEnumerable<Reponse> ReponseByDesc(int nbReponse);
        public void Add(Reponse reponse);
        public void Remove(Reponse reponse);
        public Reponse? GetReponseById(int id);
    }
}
