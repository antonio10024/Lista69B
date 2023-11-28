using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Command.CreateListCommand;

namespace Lista69B.Application.Background
{
    public class UpdateList69BJob : IJob
    {
        public static readonly JobKey Key = new JobKey("UpdateList69BJob", "Default");
        private readonly ILogger<UpdateList69BJob> _log;
        private readonly IMediator _mediator;

        public UpdateList69BJob(ILogger<UpdateList69BJob> log, IMediator mediator)
        {
            _log = log;
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _log.LogInformation("Inicia Ejecucion de tarea UpdateList69BJob");
            try
            {
                await _mediator.Send(new CreateListCommandRequest());
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                
            }

            _log.LogInformation("Termina UpdateList69BJob");
            return ;
        }
    }
}
