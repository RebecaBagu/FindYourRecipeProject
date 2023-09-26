using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
    public class RecipeService : APIService, IRecipeService

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
            throw new NotImplementedException();
        }

        public Task<RecipeResponseModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecipeResponseModel>> GetByIngredientsAsync(List<int> list)
        {
            string query = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(query))
                    query = "list=" + list[i];
                else
                    query = query + "&list=" + list[i];
            }
            return GetAsync<List<RecipeResponseModel>>($"/recipes/by-ingredients?{query}");
        }

        public Task<RecipeResponseModel> UpdateAsync(int id, CreateOrUpdateRecipeRequestModel requestModel)
        {
            return PutAsync<RecipeResponseModel>($"/recipes/{id}", requestModel);
        }
    }
}


