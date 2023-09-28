using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
	public class RecipeService: APiService, IRecipeService
	{
        public RecipeService(HttpClient client) : base(client)
        {
        }

        public Task<RecipeResponseModel> CreateAsync(CreateOrUpdateRecipeRequestModel requestModel)
        {
            return PostAsync<RecipeResponseModel>("/recipes", requestModel);
        }

        public Task DeleteAsync(int id)
        {
            return DeleteAsync($"/recipes/{id}");
        }

        public Task<List<RecipeResponseModel>> GetAsync()
        {
            return GetAsync<List<RecipeResponseModel>>("/recipes");
        }

        public Task<RecipeResponseModel> GetByIdAsync(int id)
        {
            return GetAsync<RecipeResponseModel>($"/recipes/{id}");
        }

        public Task<List<RecipeResponseModel>> GetByIngredientsAsync(List<int> ingredientsIds)
        {

            string query = "";
            foreach(int id in ingredientsIds)
            {
                if (string.IsNullOrEmpty(query))
                    query = "list=" + id;
                else
                    query = query + "&list=" + id;
            }
            return  GetAsync<List<RecipeResponseModel>>($"/recipes/by-ingredients?{query}");
        }

        public Task<RecipeResponseModel> UpdateAsync(int id, CreateOrUpdateRecipeRequestModel requestModel)
        {
            return PutAsync<RecipeResponseModel>($"/recipes/{id}", requestModel);
        }
    }
}

