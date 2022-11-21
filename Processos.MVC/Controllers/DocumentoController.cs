using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Processos.MVC.Utils;
using Processos.MVC.ViewModel;
using System.Net.Mime;
using static System.Net.WebRequestMethods;

namespace Processos.MVC.Controllers
{
    public class DocumentoController : Controller
    {
        public ILogger<DocumentoController> _logger;
        private readonly INotyfService _notyf;
        string url = "https://localhost:7037/api/";

        public DocumentoController(
            ILogger<DocumentoController> logger, 
            INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<DocumentoViewModel> documentos = Enumerable.Empty<DocumentoViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);

                //HTTP GET
                var responseTask = client.GetAsync("documento");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<DocumentoViewModel>>();
                    readTask.Wait();
                    documentos = readTask.Result;
                    documentos = documentos.OrderBy(d => d.Titulo);
                }
                else
                {
                    documentos = Enumerable.Empty<DocumentoViewModel>();
                }

                return View(documentos);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await SetTiposProcessos();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DocumentoFormViewModel documento, IFormFile file)
        {
            var extesionFile = Path.GetExtension(file.FileName);

            if (!FileTypes.FileTyles.Contains(extesionFile))
               return Content("O formato do arquivo deve ser [.pdf, .doc, .docx, .xlsx]");

            var path = await Upload(file, documento.Titulo);

            documento.CaminhoArquivo = path;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);

                //HTTP POST
                var responseTask = client.PostAsJsonAsync<DocumentoFormViewModel>("documento", documento);
                responseTask.Wait();
                var result = responseTask.Result;
               
                if (result.IsSuccessStatusCode)
                {
                    _notyf.Success("Documento cadastrado com sucesso", 5);
                    return RedirectToAction("Index");
                }

                _notyf.Error("O documento não pode ser cadastrado por conta de erros!!", 5);
                
                await SetTiposProcessos();
                return View(documento);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Download(string path)
        {
            
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private async Task<string> Upload(IFormFile file, string titulo)
        {
            if (file == null || file.Length == 0)
                throw new BadHttpRequestException("Arquivo não selecionado");

            await IfNotExistCreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{titulo}"));

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), $"wwwroot/{titulo}",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;

        }

        public Task<bool> IfNotExistCreateDirectory(string directory)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), directory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Task.FromResult(true);
        }

        
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        private async Task SetTiposProcessos()
        {
            using (var client = new HttpClient())
            {
                //HTTP GET
                var types = await client.GetFromJsonAsync<IEnumerable<EnumerationViewModel>>
                    ($"{this.url}documento/tipos-processos");
                var list = new SelectList(types, "Id", "Name");
                ViewBag.TipoProcessos = list;

            }
        }
    }
}
