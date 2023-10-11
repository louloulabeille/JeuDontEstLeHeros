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
    public class ReponseEntityConfuration : IEntityTypeConfiguration<Reponse>
    {
        public void Configure(EntityTypeBuilder<Reponse> builder)
        {
            builder.ToTable(nameof(Reponse));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Proposition).IsRequired()
                .HasMaxLength(255);

            builder.HasMany(x => x.Questions).WithMany(x => x.Reponses);
        }
    }
}
