using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryController: ControllerBase
	{
		ICategoryRepository CategoryDataContext { get; }

		public CategoryController(ICategoryRepository categoryDataContext)
		{
			CategoryDataContext = categoryDataContext;
        }

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (CategoryDataContext.ExistsAsync(id))
				return Ok(CategoryDataContext.GetByIdAsync(id));
			else
				return NotFound();
		}

		[HttpPost("Create")]
		public IActionResult Create(string name)
		{
			return Ok(CategoryDataContext.CreateAsync(name));
		}

		[HttpPut("Update/{id}")]
		public IActionResult Update(int id, string name)
		{
			if (CategoryDataContext.ExistsAsync(id))
				return Ok(CategoryDataContext.CreateAsync(id, name));
			else
				return NotFound();
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (CategoryDataContext.ExistsAsync(id))
			{
				CategoryDataContext.DeleteAsync(id);

				return Ok();
			}
			else
				return NotFound();
        }
	}
}

