using LisaRecipes.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LisaRecipes.Application.Query
{
    public class GetRecipe: IRequest<Recipe>
    {
        public int RecipeId { get; set; }
    }
}
