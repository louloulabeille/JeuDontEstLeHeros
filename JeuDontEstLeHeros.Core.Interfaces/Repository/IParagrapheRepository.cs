using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Repository
{
    public interface IParagrapheRepository
    {
        public void Add(Paragraphe paragraphe);
        public IEnumerable<Paragraphe> GatAll();
        public void Remove(Paragraphe paragraphe);
        public void Update(Paragraphe paragraphe);
        public Paragraphe? GetParagrapheById(int id);
    }
}
