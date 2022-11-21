
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Processos.Aplicacao.Exceptions;
using Processos.Aplicacao.Interfaces;
using Processos.Aplicacao.Options;
using Processos.Aplicacao.ViewModels.Documento;
using Processos.Dominio.Core;
using Processos.Dominio.Interfaces.Comum;
using Processos.Dominio.Interfaces.Repositorios;
using Processos.Dominio.Interfaces.Storage;
using Processos.Dominio.Models;
using Processos.Dominio.Models.Enumerations;

namespace Processos.Aplicacao.Services
{
    public class DocumentoService : IDocumentoService
    {
        private IDocumentoRepository _documentoRepository;
        private IValidator<DocumentoRequest> _validator;
        private FileSettings _fileApiOptions;
        private IFileStorage _fileStorage;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public DocumentoService(
            IDocumentoRepository documentoRepository, 
            IValidator<DocumentoRequest> validator,
            IOptions<FileSettings> options,
            IFileStorage fileStorage,
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _documentoRepository = documentoRepository;
            _validator = validator;
            _fileApiOptions = options.Value;
            _fileStorage = fileStorage;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DocumentoResponse> AddDocumentoAsync(DocumentoRequest documento)
        {
            var validation = _validator.Validate(documento);

            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var documentoMapper = _mapper.Map<Documento>(documento);
            var result = await _documentoRepository.Add(documentoMapper);
            await _unitOfWork.Commit();

            return _mapper.Map<DocumentoResponse>(result);

        }

        public async Task<DocumentoResponse> AtualizaDocumento(DocumentoRequest documento, int id)
        {
            var documentoBusca = await _documentoRepository.GetById(filter: d => d.Id == id) 
                ?? throw new BadRequestException(nameof(id), $"Documento com {id} não consta na base de dados!!");

            var validation = _validator.Validate(documento);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map<DocumentoRequest, Documento>(documento, documentoBusca);
            await _documentoRepository.Update(documentoBusca);
            await _unitOfWork.Commit();

            return _mapper.Map<DocumentoResponse>(documentoBusca);

        }

        public async Task<DocumentoResponse> DeleteDocumento(int id)
        {
            var documentoBusca = await _documentoRepository.GetById(filter: d => d.Id == id)
                ?? throw new BadRequestException(nameof(id), $"Documento com {id} não consta na base de dados!!");

            await _documentoRepository.Delete(id);
            await _unitOfWork.Commit();

            return _mapper.Map<DocumentoResponse>(documentoBusca);
        }

        public async Task<DocumentoResponse> UploadArquivo(int id, IFormFile file)
        {
            var entity = await _documentoRepository.GetById(d => d.Id == id)
                ?? throw new BadRequestException(nameof(id), $"Documento com {id} não encontrado.");

            if (file == null || file.Length == 0)
                throw new BadRequestException(nameof(id), "Nenhum arquivo foi fornecido.");

            var extesionFile = Path.GetExtension(file.FileName);

            if (!_fileApiOptions.ArquivoFileTypes.Contains(extesionFile))
                throw new BadRequestException(nameof(id), "Formato de arquivo invalido.");

            if (entity.CaminhoArquivo != null)
                await _fileStorage.RemoveFile(entity.CaminhoArquivo);

            await _fileStorage.IfNotExistCreateDirectory(_fileApiOptions.ArquivoFileDirectory);

            entity.CaminhoArquivo = Path.Combine(_fileApiOptions.ArquivoFileDirectory, Guid.NewGuid().ToString() + extesionFile);
            await _fileStorage.UploadFile(file, entity.CaminhoArquivo);
            await _unitOfWork.Commit();

            return _mapper.Map<DocumentoResponse>(entity);
        }

        public async Task<DocumentoResponse> RemoveArquivo(int id)
        {
            var entity = await _documentoRepository.GetById(d => d.Id == id)
                ?? throw new BadRequestException(nameof(id), $"Documento com {id} não encontrado.");

            if (entity.CaminhoArquivo != null)
            {
                await _fileStorage.RemoveFile(entity.CaminhoArquivo);
                entity.CaminhoArquivo = null;
                await _unitOfWork.Commit();
                return _mapper.Map<DocumentoResponse>(entity);
            }
            throw new BadRequestException(nameof(id), $"Não existe nenhum arquivo no documento com id: {id}");
        }

        public FileStream GetArquivo(int id)
        {
            var entity = _documentoRepository.GetById(u => u.Id == id).GetAwaiter().GetResult()
                ?? throw new BadRequestException(nameof(id), $"Documento com {id} não encontrado.");

            var pathArquivo = _fileApiOptions.DefaultArquivoPath;

            if (entity.CaminhoArquivo != null)
                pathArquivo = entity.CaminhoArquivo;

            if (string.IsNullOrEmpty(pathArquivo))
                throw new BadRequestException(nameof(id), "Nenhum arquivo encontrado.");

            return _fileStorage.GetFile(pathArquivo);

        }

        public async Task<DocumentoResponse> GetDocumentoById(int id)
        {
            return _mapper.Map<DocumentoResponse>(await _documentoRepository.GetById(filter: d => d.Id == id));
        }

        public async Task<IEnumerable<DocumentoResponse>> GetDocumentos()
        {
            return _mapper.Map<IEnumerable<DocumentoResponse>>
                (await _documentoRepository.GetAll(include: i => i.Include(tipoProcesso => tipoProcesso.TipoProcesso)));
        }

        public IEnumerable<TipoProcesso> GetTipoProcessos()
        {
            return Enumeration.GetAll<TipoProcesso>();
        }
    }
}
