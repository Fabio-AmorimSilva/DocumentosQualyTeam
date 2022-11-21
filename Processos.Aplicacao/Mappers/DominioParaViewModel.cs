
using AutoMapper;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Aplicacao.ViewModels.TipoProcesso;
using Processos.Dominio.Models;
using Processos.Dominio.Models.Enumerations;

namespace Processos.Aplicacao.Mappers
{
    public class DominioParaViewModel : Profile
    {
        public DominioParaViewModel()
        {
            CreateMap<Documento, DocumentoResponse>();
            CreateMap<TipoProcesso, TipoProcessoResponse>();
        }
    }
}
