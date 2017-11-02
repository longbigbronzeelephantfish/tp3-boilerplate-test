using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repository
{
    /// <summary>
    /// Class responsible for Notes business logic
    /// </summary>
    public class NotesRepository : INotesRepository
    {

        private readonly DatabaseContext context;

        /// <summary>
        /// Initiliase our object here.
        /// </summary>
        /// <param name="context">DatabaseContext injected by the Dependency Injector.</param>
        public NotesRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Check if a Note exists.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <returns>true if the Note exists. false otherwise.</returns>
        public bool CheckIfExists(int id)
        {
            return context.Notes.Any(note => note.NoteId == id);
        }

        /// <summary>
        /// Check if a TodoItem exits.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <param name="todoid">Id of the TodoItem</param>
        /// <returns>true if the TodoItem exists. false otherwise.</returns>
        public bool CheckIfTodoItemExists(int id, int todoid)
        {
            return context.TodoItems.Any(todo => todo.NoteId == id && todo.TodoItemId == todoid);
        }

        /// <summary>
        /// Get all the Notes.
        /// </summary>
        /// <returns>A list of all the Notes.</returns>
        public ICollection<Note> GetAll()
        {
            return context.Notes.ToList();
        }

        /// <summary>
        /// Get a Note by id.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <returns>The Note.</returns>
        public Note GetById(int id)
        {
            return context.Notes.FirstOrDefault(item => item.NoteId == id);
        }

        /// <summary>
        /// Get TodoItems of a Note.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <returns>A list of the TodoItems.</returns>
        public ICollection<TodoItem> GetTodoItems(int id)
        {
            Note note = context.Notes.Include(i => i.TodoItems).FirstOrDefault(item => item.NoteId == id);
            note.TodoItems.ForEach(i => i.Note = null);
            return note.TodoItems;
        }

        /// <summary>
        /// Add a Note.
        /// </summary>
        /// <param name="note">Note object to be added.</param>
        public void Add(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
        }

        /// <summary>
        /// Add a TodoItem to a Note.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <param name="todo">TodoItem to be added.</param>
        public void AddTodoItem(int id, TodoItem todo)
        {
            todo.NoteId = id;
            context.TodoItems.Add(todo);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes a Note.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        public void Remove(int id)
        {
            Note note = GetById(id);
            context.Notes.Remove(note);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes a TodoItem.
        /// </summary>
        /// <param name="id">Id of the Note.</param>
        /// <param name="todoid">Id of the TodoItem.</param>
        public void RemoveTodoItem(int id, int todoid)
        {
            TodoItem item = context.TodoItems.FirstOrDefault(todo => todo.NoteId == id && todo.TodoItemId == todoid);
            context.TodoItems.Remove(item);
            context.SaveChanges();
        }  
    }
}
