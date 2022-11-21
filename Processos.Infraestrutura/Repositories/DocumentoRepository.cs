
using Processos.Dominio.Interfaces.Repositorios;
using Processos.Dominio.Models;
using Processos.Infraestrutura.Context;
using Processos.Infraestrutura.Repositories.Base;

namespace Processos.Infraestrutura.Repositories
{
    public class DocumentoRepository<T> : BaseRepository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
