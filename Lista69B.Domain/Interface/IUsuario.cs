using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain.Interface
{
    public interface IUsuario
    {
        public Guid Usuario();
        public bool SetUsuario(Guid usuario);
    }
}
