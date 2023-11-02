﻿// <auto-generated />
using System;
using Lista69B.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    [DbContext(typeof(CTXLista69B))]
    partial class CTXLista69BModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lista69B.Domain.Lista69BEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Lista69BId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lista69", (string)null);
                });

            modelBuilder.Entity("Lista69B.Domain.Lista69BRegistroEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Lista69BDetalleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<Guid>("Lista69BId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("NombredelContribuyente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronSAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDeDefinitivosDOF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDeDefinitivosSAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDePresuncionDOF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDePresuncionSAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDeSentenciaFavorableDOF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroYFechaDeOficioGlobalDeSentenciaFavorableSAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroyFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronDOF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionDOFDefinitivos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionDOFDesvirtuados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionDOFPresuntos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionDOFSentenciaFavorable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionPaginaSATDefinitivos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicacionPaginaSATDesvirtuados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicacionPaginaSATPresuntos")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublicacionPaginaSATSentenciaFavorable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituacionContribuyente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Lista69BId");

                    b.ToTable("Lista69BDetalle", (string)null);
                });

            modelBuilder.Entity("Lista69B.Domain.Lista69BRegistroEntity", b =>
                {
                    b.HasOne("Lista69B.Domain.Lista69BEntity", "Lista69B")
                        .WithMany("Items")
                        .HasForeignKey("Lista69BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lista69B");
                });

            modelBuilder.Entity("Lista69B.Domain.Lista69BEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
