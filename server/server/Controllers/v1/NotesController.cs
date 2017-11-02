using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using System.Linq;

namespace Server.Controllers.v1
{
    /// <summary>
    /// NotesController
    /// </summary>
    [Controller]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class NotesController : Controller
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        public NotesController(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Notes.
        /// </summary>
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = context.Notes.ToList();
            return Json(result);
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

            context.Notes.Add(note);
            context.SaveChanges();

            return CreatedAtAction("Get", new { id = note.NoteId }, note);
        }

        /// <summary>
        /// Deletes a Note.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Note note = context.Notes.FirstOrDefault(item => item.NoteId == id);

            if (note == null)
            {
                return NotFound();
            }

            context.Notes.Remove(note);
            context.SaveChanges();

            return new NoContentResult();
        }
    }
}