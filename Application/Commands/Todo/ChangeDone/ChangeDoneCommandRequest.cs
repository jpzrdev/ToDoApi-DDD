using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Todo.ChangeDone
{
    public class ChangeDoneCommandRequest : IRequest<ChangeDoneCommandResponse>
    {
        public Guid Id { get; set; }
    }
}