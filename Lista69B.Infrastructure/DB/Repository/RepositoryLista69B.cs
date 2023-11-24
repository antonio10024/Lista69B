using Lista69B.Domain;
using Lista69B.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB.Repository
{
    public class RepositoryLista69B : IRepositoryList69B
    {
        private readonly CTXLista69B _ctx;

        public RepositoryLista69B(CTXLista69B ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Add(Lista69BEntity lista69BEntity)
        {
            _ctx.lista69B.Add(lista69BEntity);
            var res=await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }

        public async Task<Lista69BEntity> GetByActivity()
        {
           return await _ctx.lista69B.Where(x => x.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task< List<Lista69BRegistroEntity>> GetByNameOrRFC(string name, string rfc)
        {
            var list = await this.GetByActivity();
            var lista69B = _ctx.listaRegistro.Where(x => x.Lista69BId == list.Id && x.RFC==rfc | x.NombredelContribuyente==name ).ToList();
            return lista69B;
        }

        public async Task<Lista69BEntity> ListTemporal()
        {
             return await _ctx.lista69B.Include(x => x.Items).Where(x => x.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Lista69BEntity lista69BEntity)
        {
            _ctx.lista69B.Update(lista69BEntity);
            var res=await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }
    }
}
