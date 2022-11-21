using Microsoft.Extensions.Options;
using Processos.Dominio.Interfaces.Comum;
using Processos.Dominio.Interfaces.Storage;
using Processos.Infraestrutura.Storage;
using Processos.Infraestrutura.UnitOfWork;
using Swashbuckle.AspNetCore.SwaggerGen;
using Processos.Dominio.Interfaces.Repositorios;
using Processos.Infraestrutura.Repositories;
using Processos.Aplicacao.Interfaces;
using Processos.Aplicacao.Services;
using Processos.Dominio.Models;
using FluentValidation.AspNetCore;
using Processos.Aplicacao.Validations;

namespace Processos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service, ConfigurationManager configuration)
        {
            //storage
            service.AddSingleton<IFileStorage, FileStorage>();

            //repositories
            service.AddScoped<IDocumentoRepository, DocumentoRepository<Documento>>();
            
            //options
            service.Configure<Aplicacao.Options.FileSettings>(configuration.GetSection("FileSettings"));
            
            //services
            service.AddScoped<IDocumentoService, DocumentoService>();

            //uow
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            //validators
            service.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = false;
                fv.RegisterValidatorsFromAssemblyContaining<DocumentoValidator>();
            });

            service.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return service;
        }
    }
}
