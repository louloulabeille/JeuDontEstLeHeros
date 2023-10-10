using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using JeuDontEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.DataLayer
{
    public class ParagrapheDataLayer : DataLayer<Paragraphe>, IParagrapheDataLayer
    {
        public ParagrapheDataLayer(HerosDbcontext dbcontext) : base(dbcontext)
        {
        }

    }
}
