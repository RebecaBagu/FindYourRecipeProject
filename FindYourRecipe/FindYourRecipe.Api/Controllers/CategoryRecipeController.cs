using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("category-recipes")]
    [Authorize(Roles = "Admin")]
    public class CategoriesRecipesControllers :ControllerBase
	{
		ICategoryRecipeService CategoryRecipeService { get; }

        public CategoriesRecipesControllers(ICategoryRecipeService categoryRecipeService)
		{
			CategoryRecipeService = categoryRecipeService;

        }

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await CategoryRecipeService.GetAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
            try
            {
                return Ok(await CategoryRecipeService.GetByIdAsync(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateCategoryRecipeRequestModel request)
		{
			return Ok(await CategoryRecipeService.CreateAsync(request));
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

        [HttpDelete("by-recipeId/{recipeId}")]
        public async Task<IActionResult> DeleteByRecipeIdAsync(int recipeId)
        {
            await CategoryRecipeService.DeleteByRecipeIdAsync(recipeId);
            return Ok();

        }
    }
}

