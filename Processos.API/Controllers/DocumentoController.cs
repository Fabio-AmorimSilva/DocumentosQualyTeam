using Microsoft.AspNetCore.Mvc;
using Processos.Aplicacao.Interfaces;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Dominio.Models.Enumerations;

namespace Processos.API.Controllers
{
    [ApiController]
    [Route("api/documento")]
    [ApiVersion("1.0")]
    public class DocumentoController : ControllerBase
    {
        private IDocumentoService _documentoService;

        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoResponse>> Post(DocumentoRequest documento)
        {
            return await _documentoService.AddDocumentoAsync(documento);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentoResponse>> GetById(int id)
        {
            return await _documentoService.GetDocumentoById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentoResponse>> GetAllDocumentos()
        {
            return await _documentoService.GetDocumentos();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DocumentoResponse>> Put(DocumentoRequest documento, int id)
        {
            return await _documentoService.AtualizaDocumento(documento, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DocumentoResponse>> Delete(int id)
        {
            return await _documentoService.DeleteDocumento(id);
        }

        [HttpPut("arquivo/{id:int}")]
        public async Task<ActionResult> PutArquivo([FromRoute] int id, [FromForm] IFormFile file)
        {
            var result = await _documentoService.UploadArquivo(id, file);
            return Ok(result);
        }

        [HttpDelete("arquivo/{id:int}")]
        public async Task<ActionResult> DeleteArquivo([FromRoute] int id)
        {
            var result = await _documentoService.RemoveArquivo(id);
            return Ok(result);
        }

        [HttpGet("arquivo/{id:int}")]
        public ActionResult GetArquivo([FromRoute] int id)
        {
            var result = _documentoService.GetArquivo(id);
            return Ok(result);
        }

        [HttpGet("tipos-processos")]
        public IEnumerable<TipoProcesso> GetTipoProcessos()
        {
            return _documentoService.GetTipoProcessos();
        }
    }
}
