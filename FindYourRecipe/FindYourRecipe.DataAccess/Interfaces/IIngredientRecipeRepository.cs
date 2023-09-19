using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IIngredientRecipeRepository
	{
		Task<IngredientRecipe> GetByIdAsync(int id);

		Task<IngredientRecipe> CreateAsync(int ingredientId, int recipeId, string quantity);

		Task<IngredientRecipe> UpdateAsync(int id, int ingredientId, int recipeId, string quantity);

		Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}

