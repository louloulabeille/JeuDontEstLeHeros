using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Layout
{
    /// <summary>
    /// interface de Reponse -- il est possible d'ajouter des méthodes spécifique à l'accés à la base ici
    /// </summary>
    public interface IReponseDataLayer : IDataLayer<Reponse>
    {
        /// <summary>
        /// tri les reponses par ordre décroissant Id et par nombre X
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reponse> ReponseByDesc(int nbReponse);
    }
}
