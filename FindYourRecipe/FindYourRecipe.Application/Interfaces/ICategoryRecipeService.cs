using System;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Application.Interfaces
{
	public interface ICategoryRecipeService
	{
		Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request);

		Task DeleteAsync(int id);
	}
}

