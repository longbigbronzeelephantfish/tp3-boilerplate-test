using Server.Data;

namespace Server.Seed.Internal
{
    /// <summary>
    /// Interface to represent a model seeder.
    /// </summary>
    public interface IModelSeeder
    {
        /// <summary>
        /// Seed the database if true.
        /// Do not seed the database if false.
        /// </summary>
        /// <param name="context">Seed the database through this database connection.</param>
        /// <returns>Seed the database if true. Do not seed the database if false.</returns>
        bool ShouldSeed(DatabaseContext context);

        /// <summary>
        /// Seed the database.
        /// </summary>
        /// <param name="context">Seed the database through this database connection.</param>
        void Seed(DatabaseContext context);
    }
}
