using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface ICategoryRecipeService
	{
		Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request);
		Task DeleteAsync(int id);
	}
}

