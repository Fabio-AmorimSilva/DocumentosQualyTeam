
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Models;

namespace Processos.Infraestrutura.Mappings
{
    public class CategoriaMapping : RegistroMapping<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Nome)
                .IsRequired();

            builder.HasOne(c => c.TipoProcesso)
                .WithMany()
                .HasForeignKey(c => c.IdTipoProcesso)
                .OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
