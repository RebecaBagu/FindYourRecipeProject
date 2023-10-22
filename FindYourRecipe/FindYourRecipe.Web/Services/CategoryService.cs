using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
	public class CategoryService :APiService,ICategoryService
	{
        public CategoryService(HttpClient client) : base(client)
        {
        }

        public Task<CategoryResponseModel> CreateAsync(CreateOrUpdateCategoryRequestModel request)
        {
            return PostAsync<CategoryResponseModel>("/categories", request);
        }

        public Task DeleteAsync(int id)
        {
            return DeleteAsync($"/categories/{id}");
        }

       

        public Task<List<CategoryResponseModel>> GetAsync()
        {
            return GetAsync<List<CategoryResponseModel>>("/categories");
        }

        public Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            return GetAsync<CategoryResponseModel>($"/categories/{id}");
        }

        public Task<CategoryResponseModel> UpdateAsync(int id, CreateOrUpdateCategoryRequestModel request)
        {
            return PutAsync<CategoryResponseModel>($"/categories/{id}", request);
        }
    }
}

