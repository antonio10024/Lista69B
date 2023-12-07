using AutoMapper;
using Lista69B.Application.Lista.DTO;
using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.Query
{
    public class GetList69BActiveQuery
    {
        public class GetList69BactiveQueryRequest:IRequest<List69BDTO>
        {

        }

        public class GetList69BActiveQueryHandler : IRequestHandler<GetList69BactiveQueryRequest, List69BDTO>
        {
            private readonly IRepositoryList69B _repo;
            private readonly IMapper _map;

            public GetList69BActiveQueryHandler(IRepositoryList69B repo, IMapper map)
            {
                _repo = repo ?? throw new ArgumentNullException(nameof(repo));
                _map = map ?? throw new ArgumentNullException(nameof(map));
            }

            public async Task<List69BDTO> Handle(GetList69BactiveQueryRequest request, CancellationToken cancellationToken)
            {
                var listActive =_map.Map<List69BDTO>( await _repo.ListTemporal());
                return listActive;
            }
        }
    }
}
