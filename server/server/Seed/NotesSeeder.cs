using Server.Data;
using Server.Models;
using System.Linq;
using Server.Seed.Internal;

namespace Server.Seed
{
    class NotesSeeder : IModelSeeder
    {
        public bool ShouldSeed(DatabaseContext context)
        {
            return !context.Notes.Any();
        }

        public void Seed(DatabaseContext context)
        {
            var data = new Note[]
            {
                new Note{Name="Groceries",Colour=Note.NoteColour.Red},
                new Note{Name="Assignments",Colour=Note.NoteColour.Blue},
                new Note{Name="Reading List",Colour=Note.NoteColour.Yellow}
            };

            foreach (Note item in data)
            {
                context.Notes.Add(item);
            }

            context.SaveChanges();
        }
    }
}
