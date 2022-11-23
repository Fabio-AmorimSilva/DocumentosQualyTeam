
using Processos.Aplicacao.ViewModels.Categoria;

namespace Processos.Aplicacao.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaResponse> AddCategoriaAsync(CategoriaRequest categoria);
        
        Task<IEnumerable<CategoriaResponse>> GetCategorias();
        
    }
}
