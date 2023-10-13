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
        private readonly IParagrapheRepository _paragraphes;
        private readonly IQuestionRepository _questions;

        public ParagrapheWorkOfUnit(HerosDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _paragraphes = new ParagrapheRepository(dbcontext);
            _questions = new QuestionRepository(dbcontext);
        }

        public IParagrapheRepository Paragraphes => _paragraphes;
        public IQuestionRepository Questions => _questions;

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
