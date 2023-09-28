using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("ingredient-recipes")]
	public class IngredientsRecipesControllers: ControllerBase
	{
		IIngredientRecipeService IngredientRecipeService { get; }
		public IngredientsRecipesControllers(IIngredientRecipeService ingredientRecipeService)
		{
			IngredientRecipeService = ingredientRecipeService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync( CreateIngredientRecipeRequestModel request)
		{
			return Ok(await IngredientRecipeService.CreateAsync(request));
			
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(int id, CreateIngredientRecipeRequestModel request)
		{
			return Ok(await IngredientRecipeService.UpdateAsync(id, request));
		}

		[HttpDelete("{id}")]
		public async Task< IActionResult> DeleteAsync(int id)
		{
			try
			{
				await IngredientRecipeService.DeleteAsync(id);
				return Ok();
			}
			catch (NotFoundException)
			{
				return NotFound();
			}

		}
	}
}

