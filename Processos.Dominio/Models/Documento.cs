
using Processos.Dominio.Core;
using Processos.Dominio.Models.Enumerations;

namespace Processos.Dominio.Models
{
    public class Documento: Registro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CaminhoArquivo { get; set; }
        public int IdTipoProcesso { get; set; }
        public TipoProcesso TipoProcesso { get; set; }
    }
}
