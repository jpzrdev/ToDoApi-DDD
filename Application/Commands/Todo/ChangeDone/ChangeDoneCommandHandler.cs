using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.Todo.ChangeDone
{
    public class ChangeDoneCommandHandler : IRequestHandler<ChangeDoneCommandRequest, ChangeDoneCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoRepository _toDoRepository;
        public ChangeDoneCommandHandler(IToDoListRepository toDoListRepository, IToDoRepository todoRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoRepository = todoRepository;
        }
        public async Task<ChangeDoneCommandResponse> Handle(ChangeDoneCommandRequest request, CancellationToken cancellationToken)
        {
            var todo = await _toDoRepository.Find(x => x.Id == request.Id);

            if (todo is null)
            {
                throw new Exception();
            }

            todo.UpdateDone();
            await _toDoRepository.UpdateAsync(todo);

            return todo.Adapt<ChangeDoneCommandResponse>();
        }
    }
}