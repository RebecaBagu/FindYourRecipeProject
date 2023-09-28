using System;
using FindYourRecipe.Contracts.Models;
using FindYourRecipe.DataAccess;

namespace FindYourRecipe.Application.Interfaces
{
	public interface IPhotoService
	{
        Task<PhotoResponseModel> GetByIdAsync(int id);

        Task<List<PhotoResponseModel>> GetByRecipeIdAsync(int recipeId);

        Task DeteleAsync(int id);

        Task<PhotoResponseModel> CreateAsync(CreatePhotoRequestModel request);
    }
}

