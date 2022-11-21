
namespace Processos.Aplicacao.Options
{
    public class FileSettings
    {
        public string ArquivoFileDirectory { get; set; } = "documentos\\arquivos";
        public string[] ArquivoFileTypes { get; set; } = new string[0];
        public string DefaultArquivoPath { get; set; } = "";
    }
}
