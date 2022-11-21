using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Processos.MVC.ViewModel
{
    public class DocumentoFormViewModel
    {
        [Required]
        [DisplayName("Código")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas números são permitidos")]
        public string Codigo { get; set; }

        [Required]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public string Categoria { get; set; }
        [Required]
        [DisplayName("Arquivo")]
        public string CaminhoArquivo { get; set; }

        [Required]
        [DisplayName("Tipo Processo")]
        public int IdTipoProcesso { get; set; }
    }
}
