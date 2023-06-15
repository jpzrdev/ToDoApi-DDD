using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pagination;
using MediatR;

namespace Application.Queries.TodoLists.GetToDoListById
{
    public class GetToDoListByIdRequest : IRequest<GetToDoListByIdResponse>
    {
        public Guid Id { get; set; }
    }
}