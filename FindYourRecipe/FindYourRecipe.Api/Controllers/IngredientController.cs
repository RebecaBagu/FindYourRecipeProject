using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("ingredients")]
	public class IngredientsControllers : ControllerBase
	{
		IIngredientService IngredientService { get; }
		public IngredientsControllers(IIngredientService ingredientService)
		{
			IngredientService = ingredientService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				return Ok(await IngredientService.GetByIdAsync(id));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}


		[HttpGet]
		public async Task<IActionResult> GetAsync(int skip, int take)
		{
			return Ok(await IngredientService.GetAsync(skip,take));
		}


		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateOrUpdateIngredientRequestModel request)
		{
			return Ok(await IngredientService.CreateAsync(request));
		}

		


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateIngredientRequestModel request)
		{
			try
			{
				return Ok(await IngredientService.UpdateAsync(id, request));
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
				await IngredientService.DeleteAsync(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

        }

		[HttpGet("count")]
		public async Task<IActionResult> GetCountAsync()
		{
			return Ok(await IngredientService.GetCountAsync());
		}
    }
}

