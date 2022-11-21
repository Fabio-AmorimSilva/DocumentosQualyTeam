
using Processos.Aplicacao.ViewModels.TipoProcesso;
using Processos.Dominio.Core;

namespace Processos.Aplicacao.ViewModels.Documento
{
    public class DocumentoResponse : Registro
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CaminhoArquivo { get; set; }
        public TipoProcessoResponse TipoProcesso { get; set; }
    }
}
