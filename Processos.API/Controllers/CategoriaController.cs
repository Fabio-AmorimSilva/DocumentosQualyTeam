using Microsoft.AspNetCore.Mvc;
using Processos.Aplicacao.Interfaces;
using Processos.Aplicacao.ViewModels.Categoria;

namespace Processos.API.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    [ApiVersion("1.0")]
    public class CategoriaController : ControllerBase
    {
        public ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaResponse>> GetAllCategorias()
        {
            return await _categoriaService.GetCategorias();
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponse>> Post(CategoriaRequest categoriaRequest) 
        {
            return await _categoriaService.AddCategoriaAsync(categoriaRequest);
        }

    }
}
