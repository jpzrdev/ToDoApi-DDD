using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.Todo.DeleteToDoList
{
    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommandRequest, DeleteToDoListCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        public DeleteToDoListCommandHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<DeleteToDoListCommandResponse> Handle(DeleteToDoListCommandRequest request, CancellationToken cancellationToken)
        {
            var todoList = await _toDoListRepository.Find(x => x.Id == request.Id, x => x.ToDos);

            if (todoList is null)
            {
                throw new Exception();
            }

            foreach (var todo in todoList.ToDos)
            {
                todo.SoftDelete();
            }

            todoList.SoftDelete();

            await _toDoListRepository.UpdateAsync(todoList);

            return new DeleteToDoListCommandResponse();
        }
    }
}