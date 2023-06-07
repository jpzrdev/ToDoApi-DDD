using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CreateToDo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("todo")]
        public async Task<IActionResult> CreateToDo(CreateToDoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}