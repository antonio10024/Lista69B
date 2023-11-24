using AutoMapper;
using Lista69B.Application.Lista.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Lista69B.Application.Lista.Command.AddWatchlistCommand;
using static Lista69B.Application.Lista.Query.WatchlistSweepQuery;

namespace Lista69B.API.Controllers
{
    [Route("api/[controller]")]
    public class ListaDeSeguimientoController : BaseController
    {
        private readonly IMapper _map;
        public ListaDeSeguimientoController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _map = mapper;
        }

        [HttpPost()]
        public async Task<Unit> Post(AddWatchlistDTO request)
        {
            return await _mediator.Send(new AddWatchlistCommandRequest() { RazonSocial=request.RazonSocial,RFC=request.RFC});
        }

        [HttpGet]
        public async Task<Unit> Get()
        {
            return await _mediator.Send(new WatchlistSweepQueryequest());
        }
    }
}
