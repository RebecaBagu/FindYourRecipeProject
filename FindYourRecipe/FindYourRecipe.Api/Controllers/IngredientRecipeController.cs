using System;
using FindYourRecipe.Application;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IngredientsRecipesControllers: ControllerBase
	{
		IIngredientRecipeService IngredientRecipeService { get; }
		public IngredientsRecipesControllers(IIngredientRecipeService ingredientRecipeService)
		{
			IngredientRecipeService = ingredientRecipeService;
		}

		[HttpPut]
		public async Task<IActionResult> CreateAsync( CreateIngredientRecipeRequestModel request)
		{
			return Ok(await IngredientRecipeService.CreateAsync(request));
			
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

