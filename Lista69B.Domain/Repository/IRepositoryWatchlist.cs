using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain.Repository
{
    public interface IRepositoryWatchlist
    {
        public Task<bool> add(ListaSeguimiento seguimiento);

        public Task<bool> add(List<ListaSeguimiento> listaSeguimiento);

        public Task<List<ListaSeguimiento>> GetActivos();

        public Task<ListaSeguimiento> GetByRFC(string RFC);

        public Task<bool> Active(ListaSeguimiento listaSeguimiento);

        public Task<bool> SaveFounds(WatchListSweep entity);

    }
}
