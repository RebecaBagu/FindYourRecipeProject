using System;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryRecipeController :ControllerBase
	{
		ICategoryRecipeDataContext CategoryRecipeDataContext { get; }

        public CategoryRecipeController(ICategoryRecipeDataContext categoryRecipeDataContext)
		{
			CategoryRecipeDataContext = categoryRecipeDataContext;

        }

		[HttpPost("Create")]
		public IActionResult Create(int categoryId, int recipeId)
		{
			return Ok(CategoryRecipeDataContext.Create(categoryId, recipeId));
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (CategoryRecipeDataContext.Exists(id))
			{
				CategoryRecipeDataContext.Delete(id);
				return Ok();
			}
			else
				return NotFound();
				
		}
	}
}

