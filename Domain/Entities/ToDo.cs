using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDo : BaseEntity
    {
        private ToDo(string description, Guid toDoListId)
        {
            Description = description;
            ToDoListId = toDoListId;
        }

        public string Description { get; private set; }
        public bool Done { get; private set; } = false;
        public Guid ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }

        public static ToDo Create(string description, Guid toDoListId)
        {
            return new ToDo(description, toDoListId);
        }

        public void Update(string description, Guid? todoListId)
        {
            Description = description ?? Description;
            ToDoListId = todoListId ?? ToDoListId;
        }

        public void UpdateDone()
        {
            Done = !Done;
        }

    }
}