using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Notification.SearchOnWatchListNotificacion;

namespace Lista69B.Application.Lista.Command
{
    public class CreateListCommand
    {
        public class CreateListCommandRequest : IRequest<Unit>
        {

        }

        public class CreateListCommandHandler : IRequestHandler<CreateListCommandRequest, Unit>
        {
            private readonly IList69BSource _list69BSource;
            private readonly IRepositoryList69B _repositoryLista69B;
            private readonly IMediator _mediator;

            public CreateListCommandHandler(IList69BSource list69BSource, IRepositoryList69B repositoryLista69B, IMediator mediator)
            {
                _list69BSource = list69BSource;
                _repositoryLista69B = repositoryLista69B;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateListCommandRequest request, CancellationToken cancellationToken)
            {
                //Obtener listado sat

                var lista69 = await _list69BSource.UploadFile();

                //validar si el listado existe en la bd
                var listaActive = await _repositoryLista69B.GetByActivity();

                if (listaActive is not null)
                {
                    if (listaActive.Name != lista69.Name)
                    {
                        listaActive.Inactive();
                        await _repositoryLista69B.Update(listaActive);
                        return  Unit.Value;
                    }
                    else
                    {
                        return Unit.Value;
                    }
                }

                await _repositoryLista69B.Add(lista69);
                await _mediator.Publish(new SearchOnWatchListNotificacionRequest());
                return Unit.Value;
            }
        }
    }
}
