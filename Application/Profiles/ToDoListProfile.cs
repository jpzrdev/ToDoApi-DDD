using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CreateToDoList;
using Application.DTO;
using Application.Pagination;
using Domain.Entities;
using Mapster;

namespace Application.Profiles
{
    public class ToDoListProfile
    {
        public static void Map()
        {
            TypeAdapterConfig<PaginatedData<ToDoListResponseDTO>, PaginatedResponse>
            .NewConfig()
            .Map(dest => dest.Items);
        }
    }
}