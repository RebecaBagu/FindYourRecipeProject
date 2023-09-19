using System;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IngredientRecipeController: ControllerBase
	{
		IIngredientRecipeRepository IngredientRecipeDataContext { get; }
		public IngredientRecipeController(IIngredientRecipeRepository ingredientRecipeDataContext)
		{
			IngredientRecipeDataContext = ingredientRecipeDataContext;
		}

		[HttpPut("Create")]
		public IActionResult Update( int recipeId, int ingredientId, string quantity)
		{
			
			var result = IngredientRecipeDataContext.CreateAsync( recipeId, ingredientId, quantity);
			return Ok(result);
			
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			IngredientRecipeDataContext.DeleteAsync(id);

            return Ok();
		}
	}
}

