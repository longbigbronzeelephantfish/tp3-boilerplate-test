using Server.Data;
using Server.Models;
using Server.Seed;
using Server.Seed.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Seed
{
    /// <summary>
    /// This class is in charge to seeding the database.
    /// </summary>
    public class DatabaseSeeder
    {
        private List<IModelSeeder> seeders;

        /// <summary>
        /// Seed the database
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(DatabaseContext context)
        {
            new DatabaseSeeder().SeedData(context);
        }

        private DatabaseSeeder()
        {
            // Store a list of IDatabaseSeeders to be called
            seeders = new List<IModelSeeder>();
            seeders.Add(new NotesSeeder());
            seeders.Add(new TodoItemsSeeder());
        }

        private void SeedData(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            
            foreach (IModelSeeder seeder in seeders)
            {
                if (seeder.ShouldSeed(context))
                {
                    Console.WriteLine($"Seeding using {seeder.GetType()}");
                    seeder.Seed(context);
                }
            }

            context.SaveChanges();
        }
    }
}
