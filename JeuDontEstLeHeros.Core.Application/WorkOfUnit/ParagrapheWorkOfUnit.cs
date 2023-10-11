using JeuDontEstLeHeros.Core.Application.Repository;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.WorkOfUnit
{
    public class ParagrapheWorkOfUnit : IParagrapheWorkOfUnit
    {
        private readonly HerosDbcontext _dbcontext;
        private readonly IParagrapheRepository _entities;

        public ParagrapheWorkOfUnit(HerosDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _entities = new ParagrapheRepository(dbcontext);
        }

        public IParagrapheRepository Entities => _entities;

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public int Save()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
