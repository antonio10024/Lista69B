using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain
{
    public class ListaSeguimiento:Auditable
    {
        public ListaSeguimiento( string RFC, string RazonSocial)
        {
            Id = Guid.NewGuid();
            this.RFC = RFC.ToUpper();
            this.RazonSocial = RazonSocial.ToUpper();
            Activo = true;
        }

        public Guid Id { get; private set; }
        public string RFC { get; private set; } = string.Empty;
        public string RazonSocial { get; private set; } = string.Empty;
        public bool Activo { get; private set; }
        
        public void Activar()
        {
            this.Activo = true;
        }
    }
}
