using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Todo.DeleteToDoList;
using Application.Commands.TodoList.CreateToDoList;
using Application.Commands.TodoList.UpdateToDoList;
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

        [HttpGet("{Id}")]
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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoListCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteToDoListCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}