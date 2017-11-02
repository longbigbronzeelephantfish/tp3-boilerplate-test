using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    /// <summary>
    /// Data model to represent a TodoItem object.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// We can't use Data Annotations to represent composite primary keys in Entity Framework Core.
        /// This static method will be called in our <see cref="Data.DatabaseContext" /> class to model the composite primary keys.
        /// </summary>
        /// <param name="modelBuilder">Use this ModelBuilder to configure the model</param>
        public static void ModelRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(model => model.TodoItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TodoItem>().HasKey(model => new { model.TodoItemId, model.NoteId });
        }

        /// <summary>
        /// Composite primary key.
        /// </summary>
        public int TodoItemId { get; set; }

        /// <summary>
        /// Composite primary key.
        /// </summary>
        [Required]
        public int? NoteId { get; set; }

        /// <summary>
        /// Name of the todoitem.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        /// <summary>
        /// Completion status of the todoitem.
        /// </summary>
        [Required]
        public bool? Completed { get; set; }

        /// <summary>
        /// Each todoitem belongs to a note
        /// <seealso cref="Models.Note"/>
        /// </summary>
        [ForeignKey("NoteId")]
        public Note Note { get; set; }
    }
}