using System;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface IIngredientRecipeService
	{
		Task DeleteAsync(int id);
		Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request);
	}
}

