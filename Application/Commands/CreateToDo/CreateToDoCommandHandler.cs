using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommandRequest, CreateToDoCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        public CreateToDoCommandHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<CreateToDoCommandResponse> Handle(CreateToDoCommandRequest request, CancellationToken cancellationToken)
        {
            var toDoList = ToDoList.Create(request.Title);
            await _toDoListRepository.AddAsync(toDoList);
            return new CreateToDoCommandResponse
            {
                Id = toDoList.Id,
                Title = toDoList.Title
            };
        }
    }
}