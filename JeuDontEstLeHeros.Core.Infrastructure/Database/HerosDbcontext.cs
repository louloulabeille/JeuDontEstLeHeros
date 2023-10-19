using JeuDontEstLeHeros.Core.Infrastructure.Database.EntityConfiguration;
using JeuDontEstLeHeros.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.Database
{
    public class HerosDbcontext : DbContext
    {
        public HerosDbcontext(DbContextOptions<HerosDbcontext> options) : base(options)
        {
        }

        public HerosDbcontext() { }

        public virtual DbSet<Aventure> Aventures { get; set; }
        public virtual DbSet<Paragraphe> Paragraphes { get; set; }
        public virtual DbSet<Reponse> Reponses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Heros;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Aventure>(new AventureEntityConfuration());
            modelBuilder.ApplyConfiguration<Paragraphe>(new ParagrapheEntityConfuration());
            modelBuilder.ApplyConfiguration<Reponse>(new ReponseEntityConfuration());
            modelBuilder.ApplyConfiguration<Question>(new QuestionEntityConfuration());
        }

    }
}
