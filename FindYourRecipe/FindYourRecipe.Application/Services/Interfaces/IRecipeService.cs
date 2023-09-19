using System;
using FindYourRecipe.Application.Models.Ingredients;

namespace FindYourRecipe.Application.Services.Interfaces
{

	public interface IRecipeService
	{
        Task<RecipeResponseModel> GetByIdAsync(int id);
        Task<List<RecipeResponseModel>> GetAsync();
        Task DeleteAsync(int id);
        Task<RecipeResponseModel> UpdateAsync(int id, CreateOrUpdateRecipeRequestModel requestModel);
        Task<RecipeResponseModel> CreateAsync(CreateOrUpdateRecipeRequestModel requestModel);
        Task<List<RecipeResponseModel>> GetByIngredientsAsync(List<int> ingredientsIds);
    }
}

