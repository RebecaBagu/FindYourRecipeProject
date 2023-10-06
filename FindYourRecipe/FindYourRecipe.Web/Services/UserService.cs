using System;
using FindYourRecipe.Contracts;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.Contracts.Models.Request;
using FindYourRecipe.Contracts.Models.Response;

namespace FindYourRecipe.Web.Services
{
    public class UserService : APiService, IUserService
    {
        public UserService(HttpClient client) : base(client)
        {
        }

        public Task<UserResponseModel> CreateAsync(CreateOrUpdateUserRequestModel request)
        {
            return PostAsync<UserResponseModel>("/users", request);
        }

        public Task Delete(int id)
        {
            return DeleteAsync($"users/{id}");
        }

        public Task<List<UserResponseModel>> GetAsync()
        {
            return GetAsync<List<UserResponseModel>>("/users");
        }

        public Task<UserResponseModel> GetByIdAsync(int id)
        {
            return GetAsync<UserResponseModel>($"/users/{id}");
        }

        public Task<LoginResponseModel> LoginAsync(LoginRequestModel requestModel)
        {
            return PostAsync<LoginResponseModel>("/users/login", requestModel);
        }

        public Task<UserResponseModel> UpdateAsync(int id, CreateOrUpdateUserRequestModel request)
        {
            return PutAsync<UserResponseModel>($"/users/{id}", request);
        }
    }
}

