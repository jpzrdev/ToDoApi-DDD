using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDo : BaseEntity
    {
        private ToDo(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
        public bool Done { get; private set; } = false;
        public Guid ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }

        public static ToDo Create(string description)
        {
            return new ToDo(description);
        }

        public void UpdateDone()
        {
            Done = !Done;
        }

    }
}