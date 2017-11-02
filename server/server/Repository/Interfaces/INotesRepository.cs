using Server.Models;
using System.Collections.Generic;

namespace Server.Repository.Interfaces
{
    /// <summary>
    /// Repository to manage all the Notes and TodoItems
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Check if a Note exists
        /// </summary>
        bool CheckIfExists(int id);
        /// <summary>
        /// Check if a TodoItem exists
        /// </summary>
        bool CheckIfTodoItemExists(int id, int todoid);
        /// <summary>
        /// Get all the Notes
        /// </summary>
        ICollection<Note> GetAll();
        /// <summary>
        /// Get a Note by id
        /// </summary>
        Note GetById(int id);
        /// <summary>
        /// Get the TodoItems from a Note
        /// </summary>
        ICollection<TodoItem> GetTodoItems(int id);
        /// <summary>
        /// Add a Note
        /// </summary>
        void Add(Note note);
        /// <summary>
        /// Add a TodoItem
        /// </summary>
        void AddTodoItem(int id, TodoItem todo);
        /// <summary>
        /// Delete a Note
        /// </summary>
        void Remove(int id);
        /// <summary>
        /// Delete a TodoItem
        /// </summary>
        void RemoveTodoItem(int id, int todoid);
    }
}
