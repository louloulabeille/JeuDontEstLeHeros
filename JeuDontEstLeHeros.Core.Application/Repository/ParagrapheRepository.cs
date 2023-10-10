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
    public class ParagrapheRepository : IParagrapheRepository
    {
        private readonly IParagrapheDataLayer _dataLayer;

        public ParagrapheRepository(HerosDbcontext dbcontext)
        {
            _dataLayer = new ParagrapheDataLayer(dbcontext);
        }

        public void Add(Paragraphe paragraphe)
        {
            _dataLayer.Add(paragraphe);
        }

        public IEnumerable<Paragraphe> GatAll()
        {
            return _dataLayer.GetAll();
        }

        public Paragraphe? GetParagrapheById(int id)
        {
            return _dataLayer.GetById(id);
        }

        public void Remove(Paragraphe paragraphe)
        {
            _dataLayer.Remove(paragraphe);
        }

        public void Update(Paragraphe paragraphe)
        {
            _dataLayer.Update(paragraphe);
        }
    }
}
