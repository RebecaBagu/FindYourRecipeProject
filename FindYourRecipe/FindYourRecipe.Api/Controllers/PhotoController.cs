using System;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PhotoController :ControllerBase
	{
		IRecipeRepository RecipeDataContext { get; }
		IPhotoRepository PhotoDataContext { get; }
		public PhotoController(IPhotoRepository photoDataContext, IRecipeRepository recipeDataContext)
		{
			PhotoDataContext = photoDataContext;
			RecipeDataContext = recipeDataContext;

        }

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (PhotoDataContext.ExistsAsync(id))
				return Ok(PhotoDataContext.GetByIdAsync(id));
			else
				return NotFound();
		}

		[HttpGet("Get/{recipeId}")]
		public IActionResult GetByRecipeId(int recipeId)
		{
			if (RecipeDataContext.ExistsAsync(recipeId))
			{
				return Ok(PhotoDataContext.GetByRecipeIdAsync(recipeId));
			}
			else
				return NotFound();
		}

		[HttpPost("Create")]
		public IActionResult Create(int recipeId, string link)
		{
			return Ok(PhotoDataContext.CreateAsync(recipeId, link));
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			PhotoDataContext.DeteleAsync(id);
			return Ok();
		}
	}
}

