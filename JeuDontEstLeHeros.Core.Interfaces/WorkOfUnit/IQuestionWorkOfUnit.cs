using JeuDontEstLeHeros.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit
{
    public interface IQuestionWorkOfUnit : IDisposable
    {
        public IQuestionRepository Entities { get; }
        //public IQuestionRepository GetInstance();
        public int save();
    }
}
