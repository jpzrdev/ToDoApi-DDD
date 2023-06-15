using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommandRequest, CreateToDoCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoRepository _toDoRepository;
        public CreateToDoCommandHandler(IToDoListRepository toDoListRepository, IToDoRepository todoRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoRepository = todoRepository;
        }
        public async Task<CreateToDoCommandResponse> Handle(CreateToDoCommandRequest request, CancellationToken cancellationToken)
        {
            var todoList = await _toDoListRepository.GetByIdAsync(request.ToDoListId);

            if (todoList is null)
            {
                throw new Exception();
            }

            todoList.AddNewToDo(ToDo.Create(request.Description));
            await _toDoListRepository.UpdateAsync(todoList);

            return todoList.Adapt<CreateToDoCommandResponse>();
        }
    }
}