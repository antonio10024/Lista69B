using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.DTO
{
    public class ItemListFoundDTO
    {
        public string FoundRFC { get; set; }
        
        public List<RegistroLista69BDTO> registroLista69B { get; set; }

    }
}
