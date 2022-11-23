using Processos.Dominio.Interfaces.Repositorios;
using Processos.Dominio.Models;
using Processos.Infraestrutura.Context;
using Processos.Infraestrutura.Repositories.Base;

namespace Processos.Infraestrutura.Repositories
{
    public class CategoriaRepository<T> : BaseRepository<Categoria>, ICategoriaRepository
    { 
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
