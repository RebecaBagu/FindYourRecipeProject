﻿using System;

using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface IIngredientService
	{
		Task<IngredientResponseModel> GetByIdAsync(int id);

		Task<List<IngredientResponseModel>> GetAsync(int skip, int take);

		Task<IngredientResponseModel> CreateAsync(CreateOrUpdateIngredientRequestModel requestModel);

		Task<IngredientResponseModel> UpdateAsync(int id,CreateOrUpdateIngredientRequestModel requestModel);

		Task DeleteAsync(int id);

        Task<int> GetCountAsync();
    }
}

