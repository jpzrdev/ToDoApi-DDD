using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.TodoList.UpdateToDoList
{
    public class UpdateToDoListCommandRequest : IRequest<UpdateToDoListCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}