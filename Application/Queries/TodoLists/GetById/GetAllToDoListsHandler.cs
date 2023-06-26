using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries.TodoLists.GetToDoListById
{
    public class GetToDoListByIdHandler : IRequestHandler<GetToDoListByIdRequest, GetToDoListByIdResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;

        public GetToDoListByIdHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<GetToDoListByIdResponse> Handle(GetToDoListByIdRequest request, CancellationToken cancellationToken)
        {
            var toDoList = await _toDoListRepository.Find(x => x.Id == request.Id);
            return toDoList.Adapt<GetToDoListByIdResponse>();
        }
    }
}