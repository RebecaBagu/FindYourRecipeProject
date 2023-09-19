using System;

using FindYourRecipe.Application.Models.Ingredients;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application.Services.Interfaces
{
	public interface IIngredientService
	{
		Task<IngredientResponseModel> GetByIdAsync(int id);
		Task<List<IngredientResponseModel>> GetAsync();
		Task<IngredientResponseModel> CreateAsync(CreateOrUpdateIngredientRequestModel requestModel);
		Task<IngredientResponseModel> UpdateAsync(int id,CreateOrUpdateIngredientRequestModel requestModel);
		Task DeleteAsync(int id);
	}
}

