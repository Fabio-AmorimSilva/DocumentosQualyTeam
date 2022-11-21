
namespace Processos.Dominio.Core
{
    public abstract class Registro
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
