using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using LisaRecipes.Domain;

namespace LisaRecipes.Application.Command.Recipes
{
    public class Create: IRequest
    {
        public Recipe Recipe { get; set; }
    }
}
