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
    public class QuestionEntityConfuration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable(nameof(Question));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titre).IsRequired()
                .HasMaxLength(255);

            builder.HasMany(x => x.Reponses)
                .WithMany(x=>x.Questions);

            builder.HasMany(x => x.Paragraphes)
                .WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);
        }
    }
}
