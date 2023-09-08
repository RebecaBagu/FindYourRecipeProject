using System;
using FindYourRecipe.Api.Dto;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RecipeController :ControllerBase
	{
		IRecipeDataContext RecipeDataContext { get; }
		public RecipeController(IRecipeDataContext recipeDataContext)
		{
			RecipeDataContext = recipeDataContext;

		}

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (RecipeDataContext.Exists(id))
				return Ok(RecipeDataContext.GetById(id));
			else
				return NotFound();
			
		}

		[HttpGet("Get")]
		public IActionResult Get()
		{
			return Ok(RecipeDataContext.Get());
		}

		[HttpGet("GetByIngredients")]
		public IActionResult GetRecipeByIngredients([FromQuery] List<int>ingredientIds)
		{
			return Ok(RecipeDataContext.GetByIngredients(ingredientIds));
		}

		[HttpPost("Create")]
		public IActionResult Create([FromQuery] RecipeCreateOrUpdateDto request)
		{
			var recipe = RecipeDataContext.Create(request.Title, request.Description, request.Cuisine, request.Dificulty, request.RecipeLink);
			return Ok(recipe);
        }

		[HttpPut("Update/{id}")]
		public IActionResult Update(int id, [FromQuery] RecipeCreateOrUpdateDto request)
		{
			if(RecipeDataContext.Exists(id))
				return Ok(RecipeDataContext.Update(id, request.Title, request.Description, request.Cuisine, request.Dificulty, request.RecipeLink));
			else
				return NotFound();
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			RecipeDataContext.DeleteById(id);

            return Ok();
		}
	}
}

