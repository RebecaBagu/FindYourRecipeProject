using System;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryRecipeController :ControllerBase
	{
		ICategoryRecipeRepository CategoryRecipeDataContext { get; }

        public CategoryRecipeController(ICategoryRecipeRepository categoryRecipeDataContext)
		{
			CategoryRecipeDataContext = categoryRecipeDataContext;

        }

		[HttpPost("Create")]
		public IActionResult Create(int categoryId, int recipeId)
		{
			return Ok(CategoryRecipeDataContext.CreateAsync(categoryId, recipeId));
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (CategoryRecipeDataContext.ExistsAsync(id))
			{
				CategoryRecipeDataContext.DeleteAsync(id);
				return Ok();
			}
			else
				return NotFound();
				
		}
	}
}

