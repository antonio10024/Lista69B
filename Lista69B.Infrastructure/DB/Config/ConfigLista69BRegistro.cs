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
    public class ConfigLista69BRegistro : IEntityTypeConfiguration<Domain.Lista69BRegistroEntity>
    {
        public void Configure(EntityTypeBuilder<Lista69BRegistroEntity> builder)
        {
            builder.ToTable("Lista69BDetalle");
            builder.Property(x => x.id).HasColumnName("Lista69BDetalleId");
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Lista69B).WithMany(x => x.Items).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.Lista69BId);
        }
    }
}
