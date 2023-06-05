using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoApiContext dbContext) : base(dbContext)
        {

        }
    }
}