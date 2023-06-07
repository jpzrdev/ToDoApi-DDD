using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Queries.GetAllToDoLists
{
    public class GetAllToDoListsHandler : IRequestHandler<GetAllToDoListsRequest, GetAllToDoListsResponse>
    {
        public Task<GetAllToDoListsResponse> Handle(GetAllToDoListsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}