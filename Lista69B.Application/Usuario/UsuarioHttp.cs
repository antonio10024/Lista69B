using Lista69B.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Usuario
{
    public class UsuarioHttp : IUsuario
    {
        private Guid _usuarioId=Guid.Empty;
        public bool SetUsuario(Guid usuario)
        {
            _usuarioId = usuario;
            return true;
        }

        public Guid Usuario()
        {
            return _usuarioId;
        }
    }
}
