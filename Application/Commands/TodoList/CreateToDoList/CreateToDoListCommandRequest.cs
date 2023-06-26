using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.TodoList.CreateToDoList
{
    public class CreateToDoListCommandRequest : IRequest<CreateToDoListCommandResponse>
    {
        public string Title { get; set; }
    }
}