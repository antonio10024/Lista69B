using AutoMapper;
using FluentValidation;
using Lista69B.Domain;
using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.Command
{
    public class AddWatchlistCommand
    {
        public class AddWatchlistCommandRequest : IRequest<Unit>
        {
            public string RFC { get; set; } = string.Empty;
            public string RazonSocial { get; set; } = string.Empty;
        }

        public class AddWatchlistCommandValidator : AbstractValidator<AddWatchlistCommandRequest>
        {
            public AddWatchlistCommandValidator()
            {
                RuleFor(x => x.RFC).NotEmpty().Matches("[A-ZÑ&]{3,4}\\d{6}[A-V1-9][A-Z1-9][0-9A]");
                RuleFor(x => x.RazonSocial).NotEmpty().MinimumLength(3);
            }
        }

        public class AddWatchlistCommandHandler : IRequestHandler<AddWatchlistCommandRequest, Unit>
        {
            private readonly IRepositoryWatchlist _repo;
            private readonly IMapper _map;

            public AddWatchlistCommandHandler(IRepositoryWatchlist repo,IMapper mapper)
            {
                _repo = repo;
                _map = mapper;
            }

            public async Task<Unit> Handle(AddWatchlistCommandRequest request, CancellationToken cancellationToken)
            {
                var exist = await _repo.GetByRFC(request.RFC);
                if(exist is  null)
                {
                    var result = await _repo.add(_map.Map<ListaSeguimiento>(request));
                    if (!result)
                    {
                        throw new Exception("Error en base de datos");
                    }
                }
                else if(!exist.Activo)
                {
                    exist.Activar();
                    if (!await _repo.Active(exist))
                    {
                        throw new Exception("Error en base de datos");
                    }
                }
              
                return Unit.Value;
            }
        }
    }
}
