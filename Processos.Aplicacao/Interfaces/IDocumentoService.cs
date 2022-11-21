
using Microsoft.AspNetCore.Http;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Aplicacao.ViewModels.TipoProcesso;
using Processos.Dominio.Models.Enumerations;
using System.Collections;

namespace Processos.Aplicacao.Interfaces
{
    public interface IDocumentoService
    {
        Task<DocumentoResponse> AddDocumentoAsync(DocumentoRequest documento);
        Task<DocumentoResponse> AtualizaDocumento(DocumentoRequest documento, int id);
        Task<DocumentoResponse> DeleteDocumento(int id);
        Task<DocumentoResponse> GetDocumentoById(int id);
        Task<DocumentoResponse> UploadArquivo(int id, IFormFile file);
        Task<DocumentoResponse> RemoveArquivo(int id);
        FileStream GetArquivo(int id);
        Task<IEnumerable<DocumentoResponse>> GetDocumentos();
        IEnumerable<TipoProcesso> GetTipoProcessos();
    }
}
