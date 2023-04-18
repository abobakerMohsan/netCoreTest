using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.Employes.Commands.CreateEmploye;
using Products.Application.Features.Employes.Queries.GetEmployeDetail;
using Products.Application.Features.Employes.Queries.GetEmployesList;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Projects.Api.Controllers
{

    [Route("api/employes/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeController : ControllerBase
    {


        private readonly IMediator _mediator;

        public EmployeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allEmployes", Name = "GetAllEmployes")]
        public async Task<ActionResult<List<GetEmployesListViewModel>>> GetAllEmployess()
        {
            var dtos = await _mediator.Send(new GetEmployesListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEmployeById")]
        public async Task<ActionResult<GetEmployeDetailViewModel>> GetEmployeById(Guid id)
        {
            var getEventDetailQuery = new GetEmployeDetailQuery() { EmployeId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddEmploye")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeCommand createEmployeCommand)
        {
            Guid id = await _mediator.Send(createEmployeCommand);
            return Ok(id);
        }




    }
}
