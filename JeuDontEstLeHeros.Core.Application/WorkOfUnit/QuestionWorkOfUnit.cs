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
    public class QuestionWorkOfUnit : IQuestionWorkOfUnit
    {
        private readonly HerosDbcontext _dbcontext;
        private readonly IQuestionRepository _repository;

        public QuestionWorkOfUnit(HerosDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _repository = new QuestionRepository(dbcontext);
        }

        public IQuestionRepository Questions => _repository;

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public int save()
        {
            return _dbcontext.SaveChanges(); 
        }
    }
}
