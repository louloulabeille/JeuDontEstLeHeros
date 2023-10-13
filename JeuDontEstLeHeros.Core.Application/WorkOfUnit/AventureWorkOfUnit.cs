﻿using JeuDontEstLeHeros.Core.Application.Repository;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Repository;
using JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.WorkOfUnit
{
    /// <summary>
    /// Class work of unit pour le paragraphe il va falloir ajouter la possibilité d'avoir les paragraphe en plus dedans
    /// </summary>
    public class AventureWorkOfUnit : IAventureWorkOfUnit
    {
        private readonly HerosDbcontext _dbcontext;
        private readonly IAventureRepository _repository;

        public AventureWorkOfUnit(HerosDbcontext dbcontext )
        {
            _dbcontext = dbcontext;
            _repository = new AventureRepository(dbcontext);
        }

        public IAventureRepository Aventures => _repository;

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
