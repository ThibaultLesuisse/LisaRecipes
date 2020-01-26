using LisaRecipes.Contracts.Repository;
using LisaRecipes.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LisaRecipes.PersistenceEF
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDBContext recipeDBContext;

        public RecipeRepository(RecipeDBContext recipeDBContext)
        {
            this.recipeDBContext = recipeDBContext ?? throw new ArgumentNullException(nameof(recipeDBContext));
        }

        public async Task Delete(int id)
        {
            var recipe = await recipeDBContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            
            if (recipe == null) throw new Exception();

            recipeDBContext.Recipes.Remove(recipe);
        }


        public async Task<Recipe> Create(Recipe obj)
        {
            await recipeDBContext.Recipes.AddAsync(obj);
            return obj;
        }

        public async Task<Recipe> Get(int id)
        {
            return await recipeDBContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

       public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await recipeDBContext.Recipes.ToArrayAsync();
        }

        public async Task<Recipe> Update(Recipe obj)
        {
            var recipe = await recipeDBContext.Recipes.FirstOrDefaultAsync(r => r.Id == obj.Id);
            foreach(var prop in typeof(Recipe).GetProperties())
            {
                var val = prop.GetValue(obj);
                typeof(Recipe).GetProperty(prop.Name).SetValue(recipe, val);
            }
            return recipe;
        }
    }
}
