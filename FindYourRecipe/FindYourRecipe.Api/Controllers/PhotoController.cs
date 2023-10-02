using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("photos")]
	public class PhotosControllers :ControllerBase
	{
		IRecipeService RecipeService { get; }
		IPhotoService PhotoService { get; }
		public PhotosControllers(IPhotoService photoService, IRecipeService recipeService)
		{
			PhotoService = photoService;
			RecipeService = recipeService;

        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				return Ok(await PhotoService.GetByIdAsync(id));
			}
			catch(NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpGet("{recipeId}")]
		public async Task<IActionResult> GetByRecipeIdAsync(int recipeId)
		{
			try
			{
				return Ok(await PhotoService.GetByRecipeIdAsync(recipeId));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreatePhotoRequestModel request)
		{
			return Ok(await PhotoService.CreateAsync(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				await PhotoService.DeteleAsync(id);
				return Ok();
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

        [HttpDelete("by-recipeId/{recipeId}")]
        public async Task<IActionResult> DeleteByRecipeIdAsync(int recipeId)
        {
			await PhotoService.DeleteByRecipeIdAsync(recipeId);
            return Ok();

        }
    }
}

