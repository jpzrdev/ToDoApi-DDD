using Domain.Entities;
using System;
using Xunit;

namespace Domain.Tests.Entities
{
    public class ToDoTests
    {
        [Fact]
        public void Create_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string description = "Test ToDo";
            Guid toDoListId = Guid.NewGuid();

            // Act
            ToDo toDo = ToDo.Create(description, toDoListId);

            // Assert
            Assert.Equal(description, toDo.Description);
            Assert.False(toDo.Done);
            Assert.Equal(toDoListId, toDo.ToDoListId);
            Assert.Null(toDo.ToDoList);
        }

        [Fact]
        public void Update_ShouldUpdateProperties()
        {
            // Arrange
            string initialDescription = "Initial ToDo";
            string newDescription = "Updated ToDo";
            Guid initialToDoListId = Guid.NewGuid();
            Guid newToDoListId = Guid.NewGuid();
            ToDo toDo = ToDo.Create(initialDescription, initialToDoListId);

            // Act
            toDo.Update(newDescription, newToDoListId);

            // Assert
            Assert.Equal(newDescription, toDo.Description);
            Assert.Equal(newToDoListId, toDo.ToDoListId);
        }

        [Fact]
        public void Update_ShouldNotUpdateAnyProperty_WhenNullPassed()
        {
            // Arrange
            string initialDescription = "Initial ToDo";
            Guid toDoListId = Guid.NewGuid();
            ToDo toDo = ToDo.Create(initialDescription, toDoListId);

            // Act
            toDo.Update(null, null);

            // Assert
            Assert.Equal(initialDescription, toDo.Description);
            Assert.Equal(toDoListId, toDo.ToDoListId);

        }

        [Fact]
        public void UpdateDone_ShouldToggleDoneProperty()
        {
            // Arrange
            string description = "Test ToDo";
            Guid toDoListId = Guid.NewGuid();
            ToDo toDo = ToDo.Create(description, toDoListId);

            // Act
            toDo.UpdateDone(); // Toggle once
            bool doneAfterFirstToggle = toDo.Done;
            toDo.UpdateDone(); // Toggle again
            bool doneAfterSecondToggle = toDo.Done;

            // Assert
            Assert.True(doneAfterFirstToggle);
            Assert.False(doneAfterSecondToggle);
        }
    }
}
