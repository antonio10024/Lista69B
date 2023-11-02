using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain
{
    public class Lista69BEntity
    {
        public Lista69BEntity(Guid id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
           
        }

        public void AddList(ICollection<Lista69BRegistroEntity> items)
        {
            items.ToList().ForEach(x => x.Lista69BId=this.Id);
            Items = items;
        }

        public void Inactive()
        {
            this.IsActive = false;
        }

        

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public bool IsActive { get; private set; }
        public ICollection<Lista69BRegistroEntity>? Items { get; private set; }

    }

    public class Lista69BRegistroEntity
    {
        public int id { get; set; }
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

        public Guid Lista69BId { get; set; }
        public Lista69BEntity Lista69B { get; set; }
    }
}
