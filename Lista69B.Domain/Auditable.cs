using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain
{
    public abstract class Auditable
    {
        public Guid UsuarioCreo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public Guid UsuarioModifico { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
