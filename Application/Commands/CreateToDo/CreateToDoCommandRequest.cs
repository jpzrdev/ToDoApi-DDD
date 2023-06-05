using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandRequest : IRequest<CreateToDoCommandResponse>
    {
        public string Title { get; set; }
    }
}