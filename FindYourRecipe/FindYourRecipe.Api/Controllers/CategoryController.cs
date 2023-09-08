using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoryController: ControllerBase
	{
		ICategoryDataContext CategoryDataContext { get; }

		public CategoryController(ICategoryDataContext categoryDataContext)
		{
			CategoryDataContext = categoryDataContext;
        }

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (CategoryDataContext.Exists(id))
				return Ok(CategoryDataContext.GetById(id));
			else
				return NotFound();
		}

		[HttpPost("Create")]
		public IActionResult Create(string name)
		{
			return Ok(CategoryDataContext.Create(name));
		}

		[HttpPut("Update/{id}")]
		public IActionResult Update(int id, string name)
		{
			if (CategoryDataContext.Exists(id))
				return Ok(CategoryDataContext.Update(id, name));
			else
				return NotFound();
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (CategoryDataContext.Exists(id))
			{
				CategoryDataContext.Delete(id);

				return Ok();
			}
			else
				return NotFound();
        }
	}
}

