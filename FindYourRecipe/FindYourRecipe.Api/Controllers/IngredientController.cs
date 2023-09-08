using System;
using FindYourRecipe.Api.Dto;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindYourRecipe.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IngredientController : ControllerBase
	{
		IIngredientDataContext IngredientDataContext { get; }
		public IngredientController(IIngredientDataContext ingredientDataContext)
		{
			IngredientDataContext = ingredientDataContext;
		}

		[HttpGet("Get/{id}")]
		public IActionResult GetById(int id)
		{
			if (IngredientDataContext.Exists(id))
				return Ok(IngredientDataContext.GetById(id));
			else
				return NotFound();
		}

		[HttpGet("Get")]
		public IActionResult Get()
		{
			return Ok(IngredientDataContext.Get());
		}

		[HttpPost("Create")]
		public IActionResult Create([FromQuery] IngredientCreateOrUpdate request)
		{
			var ingredient = IngredientDataContext.Create(request.Name, request.Category);
			return Ok(ingredient);
		}

		[HttpPut("Update/{id}")]
		public IActionResult Update(int id, [FromQuery] IngredientCreateOrUpdate request)
		{
			if (IngredientDataContext.Exists(id))
				return Ok(IngredientDataContext.Update(id, request.Name, request.Category));
			else
				return NotFound();
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (IngredientDataContext.Exists(id))
			{
				IngredientDataContext.DeleteById(id);
				return Ok();
			}
			else
				return NotFound();

        }
	}
}

