using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    /// <summary>
    /// This class represents the database connection.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Options should be configured in <see cref="Startup"/>.
        /// All we have to do here is pass the options to the base class.
        /// </summary>
        /// <param name="options">Options passed down from Startup</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) { }

        /// <summary>
        /// Use the ModelBuilder to configure our models.
        /// Define the model configuration in the data model class as a static method then call it from here.
        /// </summary>
        /// <param name="modelBuilder">Use this ModelBuilder to configure the model</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TodoItem.ModelRelationships(modelBuilder);
        }

        // All our data models are defined here.
        /// <summary>Notes table</summary>
        public DbSet<Note> Notes { get; set; }
        /// <summary>TodoItems table</summary>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}