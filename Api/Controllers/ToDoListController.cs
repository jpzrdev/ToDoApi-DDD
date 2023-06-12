using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CreateToDoList;
using Application.Queries.GetAllToDoLists;
using Application.Queries.GetAllToDoListsPaginated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/todo-list")]
    public class ToDoListController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ToDoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListCommandRequest request)
        {
            var response = await _mediator.Send(request);
            string url = Url.Action("GetById", new { Id = response.Id });
            return Created(url, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid identifier)
        {
            // var response = await _mediator.Send()
            return Ok();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetAllPaginated(GetAllToDoListsPaginatedRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllToDoListsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }
    }
}