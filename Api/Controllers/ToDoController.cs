using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Todo.ChangeDone;
using Application.Commands.Todo.CreateToDo;
using Application.Commands.Todo.DeleteToDo;
using Application.Commands.Todo.UpdateToDo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : BaseController
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteToDoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("done")]
        public async Task<IActionResult> Done(ChangeDoneCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}