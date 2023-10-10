using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.DataLayer
{
    public class QuestionDataLayer : DataLayer<Question> , IQuestionDataLayer
    {
        public QuestionDataLayer(HerosDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
