using Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests.Entities
{
    public class ToDoListTests
    {
        [Fact]
        public void Create_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string title = "Test ToDoList";

            // Act
            ToDoList toDoList = ToDoList.Create(title);

            // Assert
            Assert.Equal(title, toDoList.Title);
            Assert.Empty(toDoList.ToDos);
        }

        [Fact]
        public void Update_ShouldUpdateTitle()
        {
            // Arrange
            string initialTitle = "Initial ToDoList";
            string newTitle = "Updated ToDoList";
            ToDoList toDoList = ToDoList.Create(initialTitle);

            // Act
            toDoList.Update(newTitle);

            // Assert
            Assert.Equal(newTitle, toDoList.Title);
        }

        [Fact]
        public void Update_ShouldNotChangeToDos()
        {
            // Arrange
            string title = "Test ToDoList";
            ToDoList toDoList = ToDoList.Create(title);
            ToDo toDo = ToDo.Create("Test ToDo", Guid.NewGuid());
            toDoList.ToDos.Add(toDo);

            // Act
            toDoList.Update("Updated ToDoList");

            // Assert
            Assert.Single(toDoList.ToDos);
            Assert.Contains(toDo, toDoList.ToDos);
        }
    }
}
