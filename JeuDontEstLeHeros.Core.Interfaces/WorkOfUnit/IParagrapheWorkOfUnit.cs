using JeuDontEstLeHeros.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.WorkOfUnit
{
    public interface IParagrapheWorkOfUnit : IDisposable
    {
        public IParagrapheRepository Paragraphes { get; }
        public IQuestionRepository Questions { get; }
        //public IParagrapheRepository GetInstance();
        public int Save();
    }
}
