using System;
using FindYourRecipe.Contracts.Models.Request;
using FindYourRecipe.Contracts.Models.Response;

namespace FindYourRecipe.Contracts
{
	public interface IUserService
	{
        Task<UserResponseModel> CreateAsync (CreateOrUpdateUserRequestModel request);

        Task Delete(int id);

        Task<List<UserResponseModel>> GetAsync();

        Task<UserResponseModel> Update(int id, CreateOrUpdateUserRequestModel request);

        Task<LoginResponseModel> LoginAsync(LoginRequestModel requestModel);
    }
}

