namespace Processos.MVC.ViewModel
{
    public class DocumentoViewModel : RegistroViewModel
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CaminhoArquivo { get; set; }
        public EnumerationViewModel TipoProcesso { get; set; }
    }
}
