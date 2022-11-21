
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Core;

namespace Processos.Infraestrutura.Mappings
{
    public class RegistroMapping<T> : IEntityTypeConfiguration<T> where T : Registro
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasIndex(r => r.Id);
            builder.Property(r => r.CriadoEm).IsRequired();
            builder.Property(r => r.AtualizadoEm).IsRequired(false);
        }
    }
}
