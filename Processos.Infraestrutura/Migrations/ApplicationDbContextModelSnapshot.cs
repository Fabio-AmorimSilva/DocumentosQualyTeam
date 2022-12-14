// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Processos.Infraestrutura.Context;

#nullable disable

namespace Processos.Infraestrutura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Processos.Dominio.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdTipoProcesso")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("IdTipoProcesso");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Processos.Dominio.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CaminhoArquivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdTipoProcesso")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("IdTipoProcesso");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Processos.Dominio.Models.Enumerations.TipoProcesso", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoProcessos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "P1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "P2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "P3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "P4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "P5"
                        });
                });

            modelBuilder.Entity("Processos.Dominio.Models.Categoria", b =>
                {
                    b.HasOne("Processos.Dominio.Models.Enumerations.TipoProcesso", "TipoProcesso")
                        .WithMany()
                        .HasForeignKey("IdTipoProcesso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoProcesso");
                });

            modelBuilder.Entity("Processos.Dominio.Models.Documento", b =>
                {
                    b.HasOne("Processos.Dominio.Models.Enumerations.TipoProcesso", "TipoProcesso")
                        .WithMany()
                        .HasForeignKey("IdTipoProcesso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoProcesso");
                });
#pragma warning restore 612, 618
        }
    }
}
