using JeuDontEstLeHeros.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.Database.EntityConfiguration
{
    internal class ParagrapheEntityConfuration : IEntityTypeConfiguration<Paragraphe>
    {
        public void Configure(EntityTypeBuilder<Paragraphe> builder)
        {
            builder.ToTable(nameof(Paragraphe));
            builder.HasKey(p => p.Id);

            builder.Property(x=>x.Numero).IsRequired();
            builder.Property(x=>x.Titre).IsRequired().HasMaxLength(125);

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Paragraphes)
                .HasForeignKey(x=>x.QuestionId);

        }
    }
}
