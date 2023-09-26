using System;
using FindYourRecipe.Application;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriesRecipesControllers :ControllerBase
	{
		ICategoryRecipeService CategoryRecipeService { get; }

        public CategoriesRecipesControllers(ICategoryRecipeService categoryRecipeService)
		{
			CategoryRecipeService = categoryRecipeService;

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
				return Ok();
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
				
		}
	}
}

