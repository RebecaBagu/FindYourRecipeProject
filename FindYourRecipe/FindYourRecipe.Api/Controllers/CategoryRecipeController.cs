using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("category-recipes")]
	public class CategoriesRecipesControllers :ControllerBase
	{
		ICategoryRecipeService CategoryRecipeService { get; }

        public CategoriesRecipesControllers(ICategoryRecipeService categoryRecipeService)
		{
			CategoryRecipeService = categoryRecipeService;

        }

		[HttpPost]
		public async Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request)
		{
			return await CategoryRecipeService.CreateAsync(request);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				await CategoryRecipeService.DeleteAsync(id);
				return NoContent();
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}
	}
}

