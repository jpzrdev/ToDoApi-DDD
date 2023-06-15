using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries.TodoLists.GetAllToDoListsPaginated
{
    public class GetAllToDoListsPaginatedHandler : IRequestHandler<GetAllToDoListsPaginatedRequest, GetAllToDoListsPaginatedResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;

        public GetAllToDoListsPaginatedHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<GetAllToDoListsPaginatedResponse> Handle(GetAllToDoListsPaginatedRequest request, CancellationToken cancellationToken)
        {
            var toDoListsPaginated = await _toDoListRepository.GetAllPaginatedAsync(request.Page, request.Take);
            return toDoListsPaginated.Adapt<GetAllToDoListsPaginatedResponse>();
        }
    }
}