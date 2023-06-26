using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Todo.DeleteToDoList
{
    public class DeleteToDoListCommandRequest : IRequest<DeleteToDoListCommandResponse>
    {
        public Guid Id { get; set; }
    }
}