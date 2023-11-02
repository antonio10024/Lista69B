using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Lista69B.Application.Exceptions;
using Lista69B.Application.Lista.DTO;
using Lista69B.Domain;
using Lista69B.Domain.Repository;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.Query
{
    public class GetByNameAndRFC
    {
        public class GetByNameAndRFCRequest : IRequest<List<RegistroLista69BDTO>>
        {
            public string RFC { get; set; } = string.Empty;
            public string? Name { get; set; } = string.Empty;
        }

        public class GetByNameAndRFCValidation : AbstractValidator<GetByNameAndRFCRequest>
        {
            public GetByNameAndRFCValidation()
            {
                RuleFor(x => x.RFC).NotEmpty().Matches("^(([A-Z]|[a-z]|\\s){1})(([A-Z]|[a-z]){3})([0-9]{6})((([A-Z]|[a-z]|[0-9]){3}))");
                RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            }
        }

        public class GetByNameAndRFCHandler : IRequestHandler<GetByNameAndRFCRequest, List<RegistroLista69BDTO>>
        {
            private readonly IRepositoryLista69B _repo;
            private readonly IMapper _map;
   

            public GetByNameAndRFCHandler(IRepositoryLista69B repo, IMapper map)
            {
                _repo = repo;
                _map = map;
                
            }

            public async Task<List<RegistroLista69BDTO>> Handle(GetByNameAndRFCRequest request, CancellationToken cancellationToken)
            {
                var listaActiva = await _repo.GetByActivity();


                var result = await _repo.GetByNameOrRFC(request.Name, request.RFC);
                if (result is null | result.Count == 0)
                    throw new NotFoundException();

                return _map.Map<List<DTO.RegistroLista69BDTO>>( result);
                
            }
        }



    }
}
