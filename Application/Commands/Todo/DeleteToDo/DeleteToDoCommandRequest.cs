using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Todo.DeleteToDo
{
    public class DeleteToDoCommandRequest : IRequest<DeleteToDoCommandResponse>
    {
        public Guid Id { get; set; }
    }
}