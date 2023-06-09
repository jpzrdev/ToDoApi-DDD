using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pagination;
using MediatR;

namespace Application.Queries.TodoLists.GetAllToDoListsPaginated
{
    public class GetAllToDoListsPaginatedRequest : PaginatedRequest, IRequest<GetAllToDoListsPaginatedResponse>
    {
    }
}