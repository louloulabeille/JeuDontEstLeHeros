﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Application.DTO
{
    public class AventureDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom de l'aventure est obligatoire.")]
        public string Nom { get; set; } = string.Empty;
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}
