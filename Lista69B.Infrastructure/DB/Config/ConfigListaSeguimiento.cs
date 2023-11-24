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
    public class ConfigListaSeguimiento : IEntityTypeConfiguration<ListaSeguimiento>
    {
        public void Configure(EntityTypeBuilder<ListaSeguimiento> builder)
        {
            builder.ToTable("ListaSeguimiento");
            builder.Property(x => x.Id).HasColumnName("ListaSeguimientoId");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RFC).HasMaxLength(15);
            builder.Property(x => x.RazonSocial).HasMaxLength(150);

        }
    }
}
