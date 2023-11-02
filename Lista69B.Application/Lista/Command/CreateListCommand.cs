﻿using Lista69B.Domain.Interface;
using Lista69B.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            private readonly IRepositoryLista69B _repositoryLista69B;

            public CreateListCommandHandler(IList69BSource list69BSource, IRepositoryLista69B repositoryLista69B)
            {
                _list69BSource = list69BSource;
                _repositoryLista69B = repositoryLista69B;
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
                        _repositoryLista69B.Update(listaActive);
                        return  Unit.Value;
                    }
                    else
                    {
                        return Unit.Value;
                    }
                }

                _repositoryLista69B.Add(lista69);

                return Unit.Value;
            }
        }
    }
}
