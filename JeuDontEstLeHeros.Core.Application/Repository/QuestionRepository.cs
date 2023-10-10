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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IQuestionDataLayer _dataLayer;

        public QuestionRepository(HerosDbcontext dbcontext)
        {
            _dataLayer = new QuestionDataLayer(dbcontext);
        }

        public IEnumerable<Question> GetAll()
        {
            return _dataLayer.GetAll();
        }
    }
}
