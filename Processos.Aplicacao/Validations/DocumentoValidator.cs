
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Dominio.Interfaces.Repositorios;

namespace Processos.Aplicacao.Validations
{
    public class DocumentoValidator : AbstractValidator<DocumentoRequest>
    {
        public DocumentoValidator(IDocumentoRepository documentoRepository)
        {
            RuleFor(d => d.Codigo)
                .Must(codigo => documentoRepository.FirstQuery().AsNoTracking().All(d => d.Codigo != codigo))
                .WithMessage("O código já existe.");

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
