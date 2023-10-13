using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Repository
{
    public interface IAventureRepository
    {
        public IEnumerable<Aventure> GetAll();
        public void Add(Aventure aventure);
        public void Remove(Aventure aventure);
        public void Update(Aventure aventure);
        public Aventure? GetAventureById(int id);

    }
}
