using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.Todo.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommandRequest, DeleteToDoCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoRepository _toDoRepository;
        public DeleteToDoCommandHandler(IToDoListRepository toDoListRepository, IToDoRepository todoRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoRepository = todoRepository;
        }
        public async Task<DeleteToDoCommandResponse> Handle(DeleteToDoCommandRequest request, CancellationToken cancellationToken)
        {
            var todo = await _toDoRepository.Find(x => x.Id == request.Id);

            if (todo is null)
            {
                throw new Exception();
            }

            todo.SoftDelete();

            await _toDoRepository.UpdateAsync(todo);

            return new DeleteToDoCommandResponse();
        }
    }
}