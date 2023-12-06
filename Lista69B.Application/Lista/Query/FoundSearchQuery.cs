using AutoMapper;
using Lista69B.Application.Lista.DTO;
using Lista69B.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.Query
{
    public class FoundSearchQuery
    {
        public class FoundSearchQueryRequest : IRequest<ListFoundDTO>
        {

        }
        public class FounSearchQueryHandler : IRequestHandler<FoundSearchQueryRequest, ListFoundDTO>
        {
            private readonly IRepositoryWatchlist _repoFound;
            private readonly IRepositoryList69B _repoList69B;
            private readonly IMapper _map;

            public FounSearchQueryHandler(IRepositoryWatchlist repoFound, IRepositoryList69B repositoryList69B,IMapper mapper)
            {
                _repoFound = repoFound;
                _repoList69B = repositoryList69B;
                _map = mapper;
            }

            public async Task<ListFoundDTO> Handle(FoundSearchQueryRequest request, CancellationToken cancellationToken)
            {
                var result= new ListFoundDTO();
                //buscar si existe una lista con resultados
                var list =await _repoFound.GetFound();
                if(list is null)
                {

                }
                else
                {
                    result.Count = list.Founds.Count;
                    result.List = new List<ItemListFoundDTO>();
                    var itemList = new ItemListFoundDTO();
                    foreach (var item in list.Founds)
                    {

                        //obtener los datos de la lista de seguimiento
                        var watchListItem =await _repoFound.GetById(item.WatchListId);
                        itemList = new ItemListFoundDTO();
                        itemList.FoundRFC = watchListItem.RFC;
                        //obtener los datos del reqgistro de la lista 69B
                        var lista69B=await _repoList69B.Get(new Func<Domain.Lista69BEntity, bool>(x => x.Id == item.Lista69BId),x=>x.Include(x=>x.Items));
                        itemList.registroLista69B = new List<RegistroLista69BDTO>();
                        var registro = lista69B.Items.Where(x => x.id == item.Register69BId).FirstOrDefault();
                        itemList.registroLista69B.Add(_map.Map<RegistroLista69BDTO>(lista69B.Items.Where(x=>x.id==item.Register69BId).FirstOrDefault() ));
                        result.List.Add(itemList);
                        itemList = null;
                        registro = null;
                    }

                    list = null;
                    return result;
                    GC.SuppressFinalize(this);
                }
                throw new NotImplementedException();
            }
        }
    }
}
