using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ToDoApiContext : DbContext
    {
        public ToDoApiContext(DbContextOptions<ToDoApiContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

    }

}