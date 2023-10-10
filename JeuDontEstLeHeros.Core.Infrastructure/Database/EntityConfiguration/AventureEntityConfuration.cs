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
    internal class AventureEntityConfuration : IEntityTypeConfiguration<Aventure>
    {
        public void Configure(EntityTypeBuilder<Aventure> builder)
        {
            builder.ToTable(nameof(Aventure));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nom).IsRequired()
                .HasMaxLength(125);

        }
    }
}
