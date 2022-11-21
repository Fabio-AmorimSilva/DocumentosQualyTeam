
using FluentValidation;
using Processos.Aplicacao.ViewModels.Documento;

namespace Processos.Aplicacao.Validations
{
    public class DocumentoValidator : AbstractValidator<DocumentoRequest>
    {
        public DocumentoValidator()
        {
            RuleFor(d => d.Titulo)
                .MaximumLength(100)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(d => d.Categoria)
                .MaximumLength(100)
                .MinimumLength(3)
                .NotEmpty();

        }
    }
}
