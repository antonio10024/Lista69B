using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Query.WatchlistSweepQuery;

namespace Lista69B.Application.Lista.Notification
{
    public class SearchOnWatchListNotificacion
    {
        public class SearchOnWatchListNotificacionRequest: INotification
        {

        }

        public class SearchOnWatchListNotificacionHandler : INotificationHandler<SearchOnWatchListNotificacionRequest>
        {
            private readonly IMediator _mediator;
            private readonly ILogger<SearchOnWatchListNotificacionHandler> _log;

            public SearchOnWatchListNotificacionHandler(IMediator mediator, ILogger<SearchOnWatchListNotificacionHandler> log)
            {
                _mediator = mediator;
                _log = log;
            }

            public async Task Handle(SearchOnWatchListNotificacionRequest notification, CancellationToken cancellationToken)
            {
                try
                {
                    _log.LogInformation("Inicia proceso de notificacion de busque en lista de seguimiento");
                    await _mediator.Send(new WatchlistSweepQueryequest());
                }
                catch (Exception ex)
                {

                    _log.LogError(ex.Message);
                }
                
                _log.LogDebug("Finalizo Busqueda de lista de seguimiento");
                return;
            }
        }
    }
}
