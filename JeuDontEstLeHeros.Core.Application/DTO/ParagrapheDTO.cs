using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.DTO
{
    public class ParagrapheDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; } = 0;
    }
}
