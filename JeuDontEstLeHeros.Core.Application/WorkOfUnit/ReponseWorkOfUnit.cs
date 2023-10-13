using JeuDontEstLeHeros.Core.Application.Repository;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.WorkOfUnit
{
    public class ReponseWorkOfUnit : IReponseWorkOfUnit
    {
        private readonly HerosDbcontext _dbcontext;
        private readonly IReponseRepository _entities;

        public IReponseRepository Reponses => _entities;

        public ReponseWorkOfUnit(HerosDbcontext dbcontext)
        {
            _entities = new ReponseRepository(dbcontext);
            _dbcontext = dbcontext;
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return _dbcontext.SaveChanges();
        }

    }
}
