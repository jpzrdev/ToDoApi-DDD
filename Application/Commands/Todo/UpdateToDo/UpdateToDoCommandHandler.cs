using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.Todo.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommandRequest, UpdateToDoCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoRepository _toDoRepository;
        public UpdateToDoCommandHandler(IToDoListRepository toDoListRepository, IToDoRepository todoRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoRepository = todoRepository;
        }
        public async Task<UpdateToDoCommandResponse> Handle(UpdateToDoCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ToDoListId is not null)
            {
                if (await _toDoListRepository.Find(x => x.Id == request.ToDoListId, x => x.ToDos) is null)
                {
                    throw new Exception();
                }
            }

            var todo = await _toDoRepository.Find(x => x.Id == request.Id);

            if (todo is null)
            {
                throw new Exception();
            }

            todo.Update(request.Description, request.ToDoListId);
            await _toDoRepository.UpdateAsync(todo);

            return todo.Adapt<UpdateToDoCommandResponse>();
        }
    }
}