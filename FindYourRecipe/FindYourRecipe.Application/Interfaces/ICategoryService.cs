using System;
using FindYourRecipe.Application.Models.Request;
using FindYourRecipe.Application.Models.Response;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application.Interfaces
{
	public interface ICategoryService
	{
		Task<CategoryResponseModel> GetByIdAsync(int id);

        Task<CategoryResponseModel> CreateAsync(CreateOrUpdateCategoryRequestModel request);

        Task DeleteAsync(int id);

        Task<CategoryResponseModel> UpdateAsync(int id, CreateOrUpdateCategoryRequestModel request);
    }
}

