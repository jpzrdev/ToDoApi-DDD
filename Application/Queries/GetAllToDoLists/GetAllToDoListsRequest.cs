using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pagination;
using MediatR;

namespace Application.Queries.GetAllToDoLists
{
    public class GetAllToDoListsRequest : PaginatedRequest, IRequest<GetAllToDoListsResponse>
    {
    }
}