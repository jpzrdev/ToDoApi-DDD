using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ToDoAppContext dbContext) : base(dbContext)
        {

        }
    }
}