using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface ICategoryRecipeService
	{
		Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request);

		Task DeleteAsync(int id);

		Task<List<CategoryRecipeResponseModel>> GetAsync();

		Task<CategoryRecipeResponseModel> GetByIdAsync(int id);

        Task DeleteByRecipeIdAsync(int recipeId);
    }
}

