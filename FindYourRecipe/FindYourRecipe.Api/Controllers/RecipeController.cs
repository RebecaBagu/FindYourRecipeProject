using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("recipes")]
	public class RecipesControllers :ControllerBase
	{
		IRecipeService RecipeService { get; }
		public RecipesControllers(IRecipeService recipeService)
		{
			RecipeService = recipeService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				return Ok(await RecipeService.GetByIdAsync(id));
				
			}
			catch(NotFoundException)
			{
				return NotFound();
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
            return Ok(await RecipeService.GetAsync());
		}

		[HttpGet("by-ingredients")]
		public async Task<IActionResult> GetRecipeByIngredientsAsync( [FromQuery]List<int>list)
		{
			try
			{
                return Ok(await RecipeService.GetByIngredientsAsync(list));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync( CreateOrUpdateRecipeRequestModel request)
		{
			return Ok(await RecipeService.CreateAsync(request));
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateRecipeRequestModel request)
		{
			try
			{
				return Ok(await RecipeService.UpdateAsync(id, request));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				await RecipeService.DeleteAsync(id);

				return Ok();
			}
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
	}
}

