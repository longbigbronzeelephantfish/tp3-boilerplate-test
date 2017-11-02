using Server.Data;
using Server.Models;
using System.Linq;
using Server.Seed.Internal;

namespace Server.Seed
{
    class TodoItemsSeeder : IModelSeeder
    {
        public bool ShouldSeed(DatabaseContext context)
        {
            return !context.TodoItems.Any();
        }

        public void Seed(DatabaseContext context)
        {
            var data = new TodoItem[]
            {
                new TodoItem{NoteId=1,Name="Eggs",Completed=false},
                new TodoItem{NoteId=1,Name="Milk",Completed=false},
                new TodoItem{NoteId=1,Name="Bread",Completed=false},
                new TodoItem{NoteId=2,Name="Advanced Programming",Completed=true},
                new TodoItem{NoteId=2,Name="Programming Languages",Completed=false},
                new TodoItem{NoteId=2,Name="Interactive Systems",Completed=false},
                new TodoItem{NoteId=3,Name="Clean Code",Completed=false},
                new TodoItem{NoteId=3,Name="Pro Git",Completed=false},
                new TodoItem{NoteId=3,Name="To Kill a Mockingbird",Completed=false},
                new TodoItem{NoteId=3,Name="Evil by Design",Completed=false}
            };

            foreach (TodoItem item in data)
            {
                context.TodoItems.Add(item);
                context.SaveChanges();
            }
        }
    }
}
