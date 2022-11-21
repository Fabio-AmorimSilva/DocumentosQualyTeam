
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Models;

namespace Processos.Infraestrutura.Mappings
{
    public class DocumentoMapping: RegistroMapping<Documento>
    {
        public override void Configure(EntityTypeBuilder<Documento> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Categoria)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(d => d.TipoProcesso)
                .WithMany()
                .HasForeignKey(d => d.IdTipoProcesso)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
