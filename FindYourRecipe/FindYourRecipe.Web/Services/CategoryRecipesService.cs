using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
    public class CategoryRecipeService : APiService, ICategoryRecipeService
    {
        public CategoryRecipeService(HttpClient client) : base(client)
        {
        }

        public Task<CategoryRecipeResponseModel> CreateAsync(CreateCategoryRecipeRequestModel request)
        {
            return PostAsync<CategoryRecipeResponseModel>("/category-recipes", request);
        }

        public Task DeleteAsync(int id)
        {
            return DeleteAsync($"/category-recipes/{id}");
        }
    }
}

