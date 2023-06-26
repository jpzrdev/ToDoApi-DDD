using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Todo.UpdateToDo
{
    public class UpdateToDoCommandRequest : IRequest<UpdateToDoCommandResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? ToDoListId { get; set; }
    }
}