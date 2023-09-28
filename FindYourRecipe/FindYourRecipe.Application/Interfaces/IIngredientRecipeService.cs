using System;
using FindYourRecipe.Application.Models;
using FindYourRecipe.Application.Models.Response;

namespace FindYourRecipe.Application.Interfaces
{
	public interface IIngredientRecipeService
	{
		Task DeleteAsync(int id);

		Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request);
	}
}

