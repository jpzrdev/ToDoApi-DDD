using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.Todo.CreateToDo
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
            var todoList = await _toDoListRepository.Find(x => x.Id == request.ToDoListId, x => x.ToDos);

            if (todoList is null)
            {
                throw new Exception();
            }

            var todo = ToDo.Create(request.Description, todoList.Id);
            await _toDoRepository.AddAsync(todo);

            return todoList.Adapt<CreateToDoCommandResponse>();
        }
    }
}