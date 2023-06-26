using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoList : BaseEntity
    {
        private ToDoList(string title)
        {
            Title = title;
        }

        public virtual List<ToDo> ToDos { get; private set; } = new List<ToDo>();
        public string Title { get; private set; }

        public static ToDoList Create(string title)
        {
            return new ToDoList(title);
        }

        public void Update(string title)
        {
            Title = title;
        }

    }
}