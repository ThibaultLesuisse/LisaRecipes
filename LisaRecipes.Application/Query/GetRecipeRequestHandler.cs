using LisaRecipes.Contracts;
using LisaRecipes.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LisaRecipes.Application.Query
{
    public class GetRecipeRequestHandler : IRequestHandler<GetRecipe, Recipe>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetRecipeRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Recipe> Handle(GetRecipe request, CancellationToken cancellationToken)
        {
            return await unitOfWork.recipeRepository.Get(request.RecipeId);
        }
    }
}
