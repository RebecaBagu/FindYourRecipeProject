using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
    public class IngredientRecipeService : APiService, IIngredientRecipeService
    {
        public IngredientRecipeService(HttpClient client) : base(client)
        {
        }

        public Task<IngredientRecipeResponseModel> CreateAsync(CreateIngredientRecipeRequestModel request)
        {
            return PostAsync<IngredientRecipeResponseModel>("/ingredient-recipes", request);
        }

        public Task DeleteAsync(int id)
        {
            return DeleteAsync($"/ingredient-recipes/{id}");
        }

        public Task<IngredientRecipeResponseModel> UpdateAsync(int id, CreateIngredientRecipeRequestModel request)
        {
            return PutAsync<IngredientRecipeResponseModel>($"/ingredient-recipes/{id}", request);
        }
    }
}

