using JeuDontEstLeHeros.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit
{
    public interface IReponseWorkOfUnit : IDisposable
    {
        IReponseRepository Reponses { get;}
        //public IReponseRepository GetInstance();
        public int Save();
    }
}
