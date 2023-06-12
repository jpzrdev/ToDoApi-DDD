using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries.GetAllToDoLists
{
    public class GetAllToDoListsHandler : IRequestHandler<GetAllToDoListsRequest, GetAllToDoListsResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;

        public GetAllToDoListsHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<GetAllToDoListsResponse> Handle(GetAllToDoListsRequest request, CancellationToken cancellationToken)
        {
            var toDoLists = await _toDoListRepository.GetAllAsync();
            return toDoLists.Adapt<GetAllToDoListsResponse>();
        }
    }
}