
using Processos.Dominio.Core;
using Processos.Dominio.Models.Enumerations;

namespace Processos.Dominio.Models
{
    public class Categoria : Registro
    {
        public string Nome { get; set; }
        public int IdTipoProcesso { get; set; }
        public TipoProcesso TipoProcesso { get; set; }
    }
}
