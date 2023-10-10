using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Repository
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> GetAll();
    }
}
