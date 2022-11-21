
using Microsoft.VisualBasic;
using Processos.Dominio.Core;

namespace Processos.Dominio.Models.Enumerations
{
    public class TipoProcesso : Enumeration
    {

        public static TipoProcesso P1 = new(1, nameof(P1));
        public static TipoProcesso P2 = new(2, nameof(P2));
        public static TipoProcesso P3 = new(3, nameof(P3));
        public static TipoProcesso P4 = new(4, nameof(P4));
        public static TipoProcesso P5 = new(5, nameof(P5));

        public TipoProcesso(int id, string name) : base(id, name)
        {
        }
    }
}
