using System;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application.Interfaces
{
	public interface ICategoryService
	{
        Task<List<CategoryResponseModel>> GetAsync();

		Task<CategoryResponseModel> GetByIdAsync(int id);

        Task<CategoryResponseModel> CreateAsync(CreateOrUpdateCategoryRequestModel request);

        Task DeleteAsync(int id);

        Task<CategoryResponseModel> UpdateAsync(int id, CreateOrUpdateCategoryRequestModel request);
    }
}

