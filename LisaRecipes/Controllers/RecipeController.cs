using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisaRecipes.Application.Query;
using LisaRecipes.Application.Command.Recipes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LisaRecipes.Domain;

namespace LisaRecipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecipeController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recipe = await mediator.Send(new GetRecipe { RecipeId = id });
            return Ok(recipe);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Recipe recipe)
        {
            await mediator.Send(new Create { Recipe = recipe });
            return Ok();
        }
    }
}