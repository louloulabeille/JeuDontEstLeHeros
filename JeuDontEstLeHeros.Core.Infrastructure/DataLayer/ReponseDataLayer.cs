using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.DataLayer
{
    /// <summary>
    /// Datalayer de Reponse -- ici implémentation des méthodes spécificiques et
    /// s'il faut faire des modifications au niveau des méthodes de Datalayer
    /// </summary>
    public class ReponseDataLayer : DataLayer<Reponse>, IReponseDataLayer
    {
        public ReponseDataLayer(HerosDbcontext dbcontext) : base(dbcontext)
        {
        }

        public IEnumerable<Reponse> ReponseByDesc(int nbReponse)
        {
            return base._dbSet.OrderByDescending(x=>x.Id).Take(nbReponse);
        }
    }
}
