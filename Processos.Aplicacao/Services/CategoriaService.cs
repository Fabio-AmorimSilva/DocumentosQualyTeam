
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Processos.Aplicacao.Interfaces;
using Processos.Aplicacao.ViewModels.Categoria;
using Processos.Dominio.Interfaces.Comum;
using Processos.Dominio.Interfaces.Repositorios;
using Processos.Dominio.Models;

namespace Processos.Aplicacao.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CategoriaService(
            ICategoriaRepository categoriaRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoriaResponse> AddCategoriaAsync(CategoriaRequest categoria)
        {
            var categoriaMapper = _mapper.Map<Categoria>(categoria);
            var result = await _categoriaRepository.Add(categoriaMapper);
            await _unitOfWork.Commit();

            return _mapper.Map<CategoriaResponse>(result);
        }

        public async Task<IEnumerable<CategoriaResponse>> GetCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaResponse>>(
                await _categoriaRepository.GetAll(include: i => i.Include(tipoProcesso => tipoProcesso.TipoProcesso)));
        }
    }
}
