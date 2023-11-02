using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.DTO
{
    public class RegistroLista69BDTO
    {
        public int No { get; set; }
        public string RFC { get; set; }
        public string NombredelContribuyente { get; set; } = string.Empty;
        public string SituacionContribuyente { get; set; } = string.Empty;
        public string NumeroYFechaDeOficioGlobalDePresuncionSAT { get; set; } = string.Empty;
        public DateTime? PublicacionPaginaSATPresuntos { get; set; }
        public string NumeroYFechaDeOficioGlobalDePresuncionDOF { get; set; } = string.Empty;
        public string PublicacionDOFPresuntos { get; set; } = string.Empty;
        public string NumeroYFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronSAT { get; set; } = string.Empty;

        public string PublicacionPaginaSATDesvirtuados { get; set; } = string.Empty;
        public string NumeroyFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronDOF { get; set; } = string.Empty;
        public string PublicacionDOFDesvirtuados { get; set; } = string.Empty;
        public string NumeroYFechaDeOficioGlobalDeDefinitivosSAT { get; set; } = string.Empty;
        public string PublicacionPaginaSATDefinitivos { get; set; } = string.Empty;
        public string NumeroYFechaDeOficioGlobalDeDefinitivosDOF { get; set; } = string.Empty;

        public string PublicacionDOFDefinitivos { get; set; } = string.Empty;
        public string NumeroYFechaDeOficioGlobalDeSentenciaFavorableSAT { get; set; } = string.Empty;
        public string PublicacionPaginaSATSentenciaFavorable { get; set; } = string.Empty;

        public string NumeroYFechaDeOficioGlobalDeSentenciaFavorableDOF { get; set; } = string.Empty;
        public string PublicacionDOFSentenciaFavorable { get; set; } = string.Empty;
    }
}
