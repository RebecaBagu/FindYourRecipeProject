using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
	public class IngredientService : APIService,IIngredientService
	{
        public IngredientService(HttpClient client) : base(client)
        {
        }

        public Task<IngredientResponseModel> CreateAsync(CreateOrUpdateIngredientRequestModel requestModel)
        {
            return PostAsync<IngredientResponseModel>("/ingredients", requestModel);
        }

        public Task DeleteAsync(int id)
        {
            return DeleteAsync($"/ingredients/{id}");
        }

        public Task<List<IngredientResponseModel>> GetAsync()
        {
            return GetAsync<List<IngredientResponseModel>>("/ingredients");
        }

        public Task<IngredientResponseModel> GetByIdAsync(int id)
        {
            return GetAsync<IngredientResponseModel>($"/ingredients/{id}");
        }

        public Task<IngredientResponseModel> UpdateAsync(int id, CreateOrUpdateIngredientRequestModel requestModel)
        {
            return PutAsync<IngredientResponseModel>($"/ingredients/{id}", requestModel);
        }
    }
}

