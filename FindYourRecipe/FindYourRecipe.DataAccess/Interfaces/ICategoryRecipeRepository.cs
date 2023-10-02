using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface ICategoryRecipeRepository
	{
		Task<CategoryRecipe> GetByIdAsync(int id);

		Task<List<CategoryRecipe>> GetAsync();

		Task<CategoryRecipe> CreateAsync(int categoryId, int recipeId);

		Task<CategoryRecipe> UpdateAsync(int id, int categoryId, int recipeId);

		Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task DeleteByRecipeIdAsync(int recipeId);
    }
}

