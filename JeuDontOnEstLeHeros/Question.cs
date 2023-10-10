using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public ICollection<Reponse>? Reponses { get; set; }
        public ICollection<Paragraphe>? Paragraphes { get; set; }
    }
}
