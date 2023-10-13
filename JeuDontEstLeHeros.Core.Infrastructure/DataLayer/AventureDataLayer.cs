using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Models;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.DataLayer
{
    public class AventureDataLayer : DataLayer<Aventure> , IAventureDataLayer
    {
        public AventureDataLayer(HerosDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
