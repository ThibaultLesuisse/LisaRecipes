using LisaRecipes.Domain;
using Microsoft.EntityFrameworkCore;

namespace LisaRecipes.PersistenceEF
{
    public class RecipeDBContext: DbContext
    {
        public RecipeDBContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Recipe> Recipes{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


    }
}
