using LisaRecipes.Contracts;
using LisaRecipes.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LisaRecipes.PersistenceEF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeDBContext recipeDBContext;

        public UnitOfWork(RecipeDBContext recipeDBContext)
        {
            this.recipeDBContext = recipeDBContext ?? throw new ArgumentNullException(nameof(recipeDBContext));
        }
        private IRecipeRepository _recipeRepository;

        public IRecipeRepository recipeRepository { get
            {
                if(_recipeRepository == null)
                {
                    _recipeRepository = new RecipeRepository(recipeDBContext);
                }
                return _recipeRepository;
            }
        }

        public int SaveChanges()
        {
            return recipeDBContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return recipeDBContext.SaveChangesAsync();
        }
    }
}
