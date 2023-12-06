using AutoMapper;
using FluentValidation;
using Lista69B.Application.Exceptions;
using Lista69B.Application.Lista.DTO;
using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Query.GetByNameAndRFC;

namespace Lista69B.Application.Lista.Query
{
    public class GetByRFC
    {
        public class GetByRFCRequest : IRequest<List<RegistroLista69BDTO>>
        {
            public string RFC { get; set; } = string.Empty;
        }
        public class GetByRFCValidation : AbstractValidator<GetByRFCRequest>
        {
            public GetByRFCValidation()
            {
                RuleFor(x => x.RFC.ToUpper()).NotEmpty().Matches("[A-ZÑ&]{3,4}\\d{6}[A-V1-9][A-Z1-9][0-9A]");
            }
        }

        public class GetByRFCHandler : IRequestHandler<GetByRFCRequest, List<RegistroLista69BDTO>>
        {
            private readonly IRepositoryList69B _repo;
            private readonly IMapper _map;


            public GetByRFCHandler(IRepositoryList69B repo, IMapper map)
            {
                _repo = repo;
                _map = map;

            }



            public async Task<List<RegistroLista69BDTO>> Handle(GetByRFCRequest request, CancellationToken cancellationToken)
            {
                var listaActiva = await _repo.GetByActivity();


                var result = await _repo.GetByNameOrRFC(string.Empty, request.RFC);
                if (result is null | result.Count == 0)
                    throw new NotFoundException();

                return _map.Map<List<DTO.RegistroLista69BDTO>>(result);
            }
        }
    }
}
