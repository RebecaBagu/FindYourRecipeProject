using System;
namespace FindYourRecipe.DataAccess
{
	public interface IRecipeRepository
	{
		Task<Recipe> GetByIdAsync(int id);

        Task<List<Recipe>> GetAsync();

        Task<Recipe> CreateAsync(string title, string description,string cuisine, string dificulty, string recipeLink);

        Task DeleteByIdAsync(int id);

        Task<Recipe> UpdateAsync(int id, string title, string description, string cuisine, string dificulty, string recipeLink);

        Task<bool> ExistsAsync(int id);

        Task<List<Recipe>> GetByIngredientsAsync(List<int> ingredientIds);

	}
}

