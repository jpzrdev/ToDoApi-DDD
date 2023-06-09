using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace Application.Commands.CreateToDoList
{
    public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommandRequest, CreateToDoListCommandResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;
        public CreateToDoListCommandHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<CreateToDoListCommandResponse> Handle(CreateToDoListCommandRequest request, CancellationToken cancellationToken)
        {
            var toDoList = ToDoList.Create(request.Title);
            await _toDoListRepository.AddAsync(toDoList);
            return toDoList.Adapt<CreateToDoListCommandResponse>();
        }
    }
}