using System;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Models.Response;

namespace FindYourRecipe.Application.Interfaces
{
	public interface ICategoryRecipeService
	{
		Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request);

		Task DeleteAsync(int id);
	}
}

