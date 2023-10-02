using FindYourRecipe.Application;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("categories")]
	public class CategoriesControllers: ControllerBase
	{
		ICategoryService CategoryService { get; }

		public CategoriesControllers(ICategoryService categoryService)
		{
			CategoryService = categoryService;
        }

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await CategoryService.GetAsync());
		}

		[HttpGet("{id}")]
		public async Task< IActionResult> GetByIdAsync(int id)
		{
			try
			{
				return Ok(await CategoryService.GetByIdAsync(id));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateOrUpdateCategoryRequestModel request)
		{
			return Ok(await CategoryService.CreateAsync(request));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateCategoryRequestModel request)
		{
			try
			{
				return Ok(await CategoryService.UpdateAsync(id, request));
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public async Task< IActionResult> DeleteAsync(int id)
		{
			try
			{
				await CategoryService.DeleteAsync(id);
				return Ok();
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
        }

     
    }
}

