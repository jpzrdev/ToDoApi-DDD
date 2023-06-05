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

        public List<ToDo> ToDos { get; private set; }
        public string Title { get; private set; }

        public static ToDoList Create(string title)
        {
            return new ToDoList(title);
        }

        public void AddNewToDo(ToDo toDo)
        {
            ToDos.Add(toDo);
        }

        public void RemoveToDo(Guid toDoId)
        {
            var toDoToRemove = ToDos.FirstOrDefault(x => x.Id == toDoId);

            if (toDoToRemove != null)
                ToDos.Remove(toDoToRemove);
        }
    }
}