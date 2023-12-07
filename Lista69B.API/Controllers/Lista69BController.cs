using Lista69B.Application.Lista.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Lista69B.Application.Lista.Command.CreateListCommand;
using static Lista69B.Application.Lista.Query.GetByNameAndRFC;
using static Lista69B.Application.Lista.Query.GetByRFC;
using static Lista69B.Application.Lista.Query.GetList69BActiveQuery;

namespace Lista69B.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lista69BController : BaseController
    {
        public Lista69BController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// ejecuta proceso de descarga de archivo y en caso de ser una nueva lista o la primera se inserta en db 
        /// </summary>
        [HttpPost]
        public async Task<Unit> Alta()
        {
            return  await this._mediator.Send(new CreateListCommandRequest());
        }

        [HttpGet("Active")]
        public async Task<List69BDTO> Active()
        {
            return await _mediator.Send(new GetList69BactiveQueryRequest());
        }
        
        [HttpGet("GetByRFCAndName")]
        public async Task<List<RegistroLista69BDTO>> GetByRFCAndName(string rfc, string name)
        {
            return await this._mediator.Send(new GetByNameAndRFCRequest() { RFC = rfc, Name = name });
        }

        [HttpGet("GetByRFC")]
        public async Task<List<RegistroLista69BDTO>> GetByRFC(string rfc)
        {
            return await this._mediator.Send(new GetByRFCRequest() { RFC = rfc });
        }
    }
}
