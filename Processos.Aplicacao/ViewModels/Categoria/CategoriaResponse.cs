
using Processos.Aplicacao.ViewModels.TipoProcesso;
using Processos.Dominio.Core;

namespace Processos.Aplicacao.ViewModels.Categoria
{
    public class CategoriaResponse : Registro
    {
        public string Nome { get; set; }
        public TipoProcessoResponse TipoProcesso { get; set; }
    }
}
