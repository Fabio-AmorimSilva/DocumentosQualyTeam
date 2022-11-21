
namespace Processos.Aplicacao.ViewModels.Documento
{
    public class DocumentoRequest 
    { 
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CaminhoArquivo { get; set; }
        public int IdTipoProcesso { get; set; }
    }
}
