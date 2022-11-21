
using AutoMapper;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Dominio.Models;

namespace Processos.Aplicacao.Mappers
{
    public class ViewModelParaDominio : Profile
    {
        public ViewModelParaDominio()
        {
            CreateMap<DocumentoRequest, Documento>();
        }
    }
}
