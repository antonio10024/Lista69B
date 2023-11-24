using Lista69B.Application.Lista.DTO;
using Lista69B.Domain;
using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Query.GetByNameAndRFC;

namespace Lista69B.Application.Lista.Query
{
    public class WatchlistSweepQuery
    {
        public class WatchlistSweepQueryequest:IRequest<Unit>
        {

        }

        public class WatchlistSweepQueryHandler : IRequestHandler<WatchlistSweepQueryequest, Unit>
        {
            private readonly IRepositoryWatchlist _repo;
            private readonly IRepositoryList69B _repo69B;

            public WatchlistSweepQueryHandler(IRepositoryWatchlist repo,IMediator mediator,IRepositoryList69B repositoryList69B)
            {
                _repo = repo;
                _repo69B = repositoryList69B;
            }

            public async Task<Unit> Handle(WatchlistSweepQueryequest request, CancellationToken cancellationToken)
            {
                //obtener el listado
                var watchList =new ConcurrentBag <ListaSeguimiento>(  await _repo.GetActivos());
                ConcurrentBag<FoundDTO> foundList = new ConcurrentBag<FoundDTO>();

                var currentList = await _repo69B.ListTemporal();
                ConcurrentBag<Lista69BRegistroEntity> listaTemporal = new ConcurrentBag<Lista69BRegistroEntity>(currentList.Items.ToList());
                
                Parallel.ForEach(watchList, async x =>
                {
                    var search = listaTemporal.Where(y => y.RFC == x.RFC | y.NombredelContribuyente == x.RazonSocial).ToList();
                    if (search.Count > 0)
                    {
                        search.ForEach(y => foundList.Add(new FoundDTO() { List69BId = y.id, WatchListId = x.Id }));
                    }
                });

                WatchListSweep entity = new WatchListSweep();
                foundList.ToList().ForEach(x => entity.add(new FoundWatchList() { WatchListId = x.WatchListId, List69BId = x.List69BId }));

                await _repo.SaveFounds(entity);

                return Unit.Value;
                //comparar registro contra lista 

                //guardar resultado de busqueda
            }
        }
    }
}
