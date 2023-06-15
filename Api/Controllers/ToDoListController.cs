using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CreateToDo;
using Application.Commands.CreateToDoList;
using Application.Queries.TodoLists.GetAllToDoLists;
using Application.Queries.TodoLists.GetAllToDoListsPaginated;
using Application.Queries.TodoLists.GetToDoListById;
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
        public async Task<IActionResult> GetById([FromRoute] GetToDoListByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetAllPaginated([FromQuery] GetAllToDoListsPaginatedRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllToDoListsRequest());
            return Ok(response);
        }

        [HttpPost("add-todo")]
        public async Task<IActionResult> CreateToDo(CreateToDoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}