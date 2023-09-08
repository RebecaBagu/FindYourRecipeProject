using System;
using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PhotoController :ControllerBase
	{
		IRecipeDataContext RecipeDataContext { get; }
		IPhotoDataContext PhotoDataContext { get; }
		public PhotoController(IPhotoDataContext photoDataContext, IRecipeDataContext recipeDataContext)
		{
			PhotoDataContext = photoDataContext;
			RecipeDataContext = recipeDataContext;

        }

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (PhotoDataContext.Exists(id))
				return Ok(PhotoDataContext.GetById(id));
			else
				return NotFound();
		}

		[HttpGet("Get/{recipeId}")]
		public IActionResult GetByRecipeId(int recipeId)
		{
			if (RecipeDataContext.Exists(recipeId))
			{
				return Ok(PhotoDataContext.GetByRecipeId(recipeId));
			}
			else
				return NotFound();
		}

		[HttpPost("Create")]
		public IActionResult Create(int recipeId, string link)
		{
			return Ok(PhotoDataContext.Create(recipeId, link));
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			PhotoDataContext.Detele(id);
			return Ok();
		}
	}
}

