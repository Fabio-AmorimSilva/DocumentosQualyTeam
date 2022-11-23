
using Microsoft.EntityFrameworkCore;
using Processos.Dominio.Core;
using Processos.Dominio.Models;
using Processos.Dominio.Models.Enumerations;
using Processos.Infraestrutura.Mappings;

namespace Processos.Infraestrutura.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoProcesso> TipoProcessos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMapping<TipoProcesso>());
            
            modelBuilder
                .Entity<TipoProcesso>()
                .HasData(Enumeration.GetAll<TipoProcesso>());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null || entry.Entity.GetType().GetProperty("UpdatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                    entry.Property("AtualizadoEm").CurrentValue = null;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                    entry.Property("AtualizadoEm").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
