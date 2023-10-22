using System;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface IIngredientRecipeService
	{
		Task DeleteAsync(int id);

		Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request);

		Task<IngredientRecipeResponseModel> UpdateAsync(int id,CreateIngredientRecipeRequestModel request);

        Task DeleteByRecipeIdAsync(int recipeId);
    }
}

