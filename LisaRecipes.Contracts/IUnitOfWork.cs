using LisaRecipes.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LisaRecipes.Contracts
{
    public interface IUnitOfWork
    {
        public IRecipeRepository recipeRepository { get; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync();
    }
}
