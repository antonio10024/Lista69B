using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException():base("No existe Registro")
        {
            
        }
}
}
