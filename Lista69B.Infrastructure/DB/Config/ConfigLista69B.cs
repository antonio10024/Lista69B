using Lista69B.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB.Config
{
    public class ConfigLista69B : IEntityTypeConfiguration<Lista69BEntity>
    {
        public void Configure(EntityTypeBuilder<Lista69BEntity> builder)
        {
            builder.ToTable("Lista69");
            builder.Property(x => x.Id).HasColumnName("Lista69BId");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Items).WithOne(x => x.Lista69B).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.Lista69BId);
        }
    }
}
