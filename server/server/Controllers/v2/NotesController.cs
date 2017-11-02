using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using Server.Repository;
using System;
using Server.Repository.Interfaces;

namespace Server.Controllers.v2
{
    /// <summary>
    /// This Controller handles the REST API endpoints for Notes.
    /// 
    /// REST API Endpoints:
    /// 
    ///     GET api/notes
    ///     GET api/notes/{id}
    ///     GET api/notes/{id}/todoitems
    /// 
    ///     POST api/notes
    ///     POST api/notes/{id}/todoitems
    /// 
    ///     PUT api/notes/{id}
    ///     PUT api/notes/{id}/todoitems/{id}
    /// 
    ///     DELETE api/notes/{id}
    ///     DELETE api/notes/{id}/todoitems/{id}
    /// 
    /// </summary>
    [Controller]
    [Produces("application/json")]
    [Route("api/v2/[controller]")]
    public class NotesController : Controller
    {
        private readonly INotesRepository repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">NotesRepository injected into the constructor via Dependency Injection</param>
        public NotesController(INotesRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all Notes.
        /// </summary>
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(repository.GetAll());
        }

        /// <summary>
        /// Get a Note by Id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!repository.CheckIfExists(id))
            {
                return NotFound();
            }
            return Json(repository.GetById(id));
        }

        /// <summary>
        /// Get a Note's TodoItems.
        /// </summary>
        [HttpGet("{id}/todoitems")]
        public IActionResult GetTodoItems(int id)
        {
            if (!repository.CheckIfExists(id))
            {
                return NotFound();
            }
            return Json(repository.GetTodoItems(id));
        }

        /// <summary>
        /// Add a Note.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]Note note)
        {
            if (note == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.Add(note);

            return CreatedAtAction("Get", new { id = note.NoteId }, note);
        }

        /// <summary>
        /// Add a TodoItem.
        /// </summary>
        [HttpPost("{id}/todoitems")]
        public IActionResult PostTodoItem(int id, [FromBody]TodoItem todo)
        {
            if (todo == null || !ModelState.IsValid || !repository.CheckIfExists(id))
            {
                return BadRequest();
            }
            
            repository.AddTodoItem(id, todo);

            return CreatedAtAction("Get", new { id = todo.NoteId }, todo);
        }

        /*
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Note note)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut("{id}/todoitems/{todoid}")]
        public IActionResult PutTodoItem(int id, int todoid, [FromBody]TodoItem todo)
        {
            throw new NotImplementedException();
        }
        */

        /// <summary>
        /// Deletes a Note.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!repository.CheckIfExists(id))
            {
                return NotFound();
            }

            repository.Remove(id);

            return new NoContentResult();
        }

        /// <summary>
        /// Delets a TodoItem.
        /// </summary>
        [HttpDelete("{id}/todoitems/{todoid}")]
        public IActionResult Delete(int id, int todoid)
        {
            if (!repository.CheckIfExists(id) || !repository.CheckIfTodoItemExists(id, todoid))
            {
                return NotFound();
            }

            repository.RemoveTodoItem(id, todoid);

            return new NoContentResult();
        }
    }
}
