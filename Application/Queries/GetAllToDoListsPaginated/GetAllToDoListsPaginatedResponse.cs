using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Pagination;
using Domain.Entities;

namespace Application.Queries.GetAllToDoListsPaginated
{
    public class GetAllToDoListsPaginatedResponse : PaginatedData<ToDoListResponseDTO>
    {

    }
}