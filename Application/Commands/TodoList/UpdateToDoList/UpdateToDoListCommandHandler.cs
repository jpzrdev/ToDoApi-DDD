using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.TodoList.UpdateToDoList
{
    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommandRequest, UpdateToDoListCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        public UpdateToDoListCommandHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<UpdateToDoListCommandResponse> Handle(UpdateToDoListCommandRequest request, CancellationToken cancellationToken)
        {
            var todoList = await _toDoListRepository.Find(x => x.Id == request.Id, x => x.ToDos);

            if (todoList is null)
            {
                throw new Exception();
            }
            todoList.Update(request.Title);
            await _toDoListRepository.UpdateAsync(todoList);
            return todoList.Adapt<UpdateToDoListCommandResponse>();
        }
    }
}