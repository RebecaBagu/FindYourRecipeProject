using System;
using FindYourRecipe.Contracts.Models;


namespace FindYourRecipe.Application.Interfaces
{
	public interface IIngredientRecipeService
	{
		Task DeleteAsync(int id);

		Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request);
	}
}

