using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Web.Services
{
    public class PhotoService : APiService, IPhotoService
    {
        public PhotoService(HttpClient client) : base(client)
        {
        }

        public Task<PhotoResponseModel> CreateAsync(CreatePhotoRequestModel request)
        {
            return PostAsync<PhotoResponseModel>("/photos", request);
        }

        public Task DeteleAsync(int id)
        {
            return DeleteAsync($"/photos/{id}");
        }

        public Task<PhotoResponseModel> GetByIdAsync(int id)
        {
            return GetAsync<PhotoResponseModel>($"/photos/{id}");
        }

        public Task<List<PhotoResponseModel>> GetByRecipeIdAsync(int recipeId)
        {
            return GetAsync<List<PhotoResponseModel>>("/photos");
        }
    }
}

