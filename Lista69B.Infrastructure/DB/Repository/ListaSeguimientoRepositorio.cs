using Lista69B.Domain;
using Lista69B.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB.Repository
{
    public class ListaSeguimientoRepositorio : IRepositoryWatchlist
    {
        private readonly CTXLista69B _ctx;

        public ListaSeguimientoRepositorio(CTXLista69B ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Active(ListaSeguimiento listaSeguimiento)
        {
             _ctx.listaSeguimientos.Update(listaSeguimiento);
            var res = await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }

        public async Task<bool> add(ListaSeguimiento seguimiento)
        {
            await _ctx.listaSeguimientos.AddAsync(seguimiento);
            var res = await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }

        public async Task<bool> add(List<ListaSeguimiento> listaSeguimiento)
        {
            await _ctx.listaSeguimientos.AddRangeAsync(listaSeguimiento);
            var res = await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }

        public async Task<List<ListaSeguimiento>> GetActivos()
        {
            return await _ctx.listaSeguimientos.Where(x => x.Activo == true).AsNoTracking().ToListAsync();
        }

        public async Task<ListaSeguimiento> GetById(Guid id)
        {
            return await _ctx.listaSeguimientos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ListaSeguimiento> GetByRFC(string RFC)
        {
            return await _ctx.listaSeguimientos.Where(x => x.RFC.ToLower().Equals(RFC.ToLower())).FirstOrDefaultAsync();
        }

        public  Task<WatchListSweep> GetFound()
        {
            //obtener el ultimo resultado del barrido 
            return Task.FromResult( _ctx.watchListSweeps.Include(x => x.Founds).OrderByDescending(x => x.Id).FirstOrDefault());

            
        }

        public async Task<bool> SaveFounds(WatchListSweep entity)
        {
            await _ctx.watchListSweeps.AddAsync(entity);
            var res = await _ctx.SaveChangesAsync();
            return res == 0 ? false : true;
        }
    }
}
