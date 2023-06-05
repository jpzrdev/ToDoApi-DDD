using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandRequest : IRequest<CreateToDoCommandResponse>
    {
        public string Description { get; set; }
        public Guid ToDoListId { get; set; }
    }
}