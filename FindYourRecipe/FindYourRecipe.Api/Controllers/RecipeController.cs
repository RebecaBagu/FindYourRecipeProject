using System;
using FindYourRecipe.Application;
using FindYourRecipe.Application.Interfaces;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Services;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
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
		public async Task<IActionResult> GetRecipeByIngredientsAsync([FromQuery] List<int>ingredientIds)
		{
			try
			{
				return Ok(await RecipeService.GetByIngredientsAsync(ingredientIds));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromQuery] CreateOrUpdateRecipeRequestModel request)
		{
			return Ok(await RecipeService.CreateAsync(request));
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromQuery] CreateOrUpdateRecipeRequestModel request)
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

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await RecipeService.DeleteAsync(id);

            return Ok();
		}
	}
}

