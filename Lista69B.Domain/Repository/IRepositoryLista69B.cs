using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain.Repository
{
    public interface IRepositoryLista69B
    {
        public  Task<bool> Add(Lista69BEntity lista69BEntity);

        public Task<Lista69BEntity> GetByActivity();

        public Task<bool> Update(Lista69BEntity lista69BEntity);

        public Task<List<Lista69BRegistroEntity>> GetByNameOrRFC(string name, string rfc);

    }
}
