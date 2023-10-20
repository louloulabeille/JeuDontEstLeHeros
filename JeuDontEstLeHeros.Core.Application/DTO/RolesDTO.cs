using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.DTO
{
    public class RolesDTO
    {
        public string Id {  get; set; } = string.Empty;
        [Required(ErrorMessage ="Le nom du role est obligatoire. Attention il ne doit pas exister dans la base.")]
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
