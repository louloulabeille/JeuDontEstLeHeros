using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Models
{
    public class Reponse
    {
        public int Id { get; set; }
        public string Proposition { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}
