using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit
{
    public interface IAventureWorkOfUnit : IDisposable
    {
        public IAventureRepository Aventures { get; }

        public void Save();
    }
}
