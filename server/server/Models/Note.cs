using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    /// <summary>
    /// Data model to represent a Note object.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Primary Key.
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        /// Name of the note.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Colour tag of the note.
        /// <seealso cref="Note.NoteColour"/>
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public NoteColour Colour { get; set; }

        /// <summary>
        /// Each note contains a list of todoitems.
        /// <seealso cref="Models.TodoItem"/>
        /// </summary>
        public List<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// Valid colours for the note.
        /// </summary>
        public enum NoteColour
        {
            /// <summary> The colour Red. </summary>
            Red,
            /// <summary> The colour Orange. </summary>
            Orange,
            /// <summary> The colour Yellow. </summary>
            Yellow,
            /// <summary> The colour Green. </summary>
            Green,
            /// <summary> The colour Blue. </summary>
            Blue,
            /// <summary> The colour Purple. </summary>
            Purple,
            /// <summary> The colour Violet. </summary>
            Violet
        }
    }


}