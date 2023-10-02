using FindYourRecipe.Contracts.Models;

namespace FindYourRecipe.Contracts
{
	public interface IPhotoService
	{
        Task<PhotoResponseModel> GetByIdAsync(int id);

        Task<List<PhotoResponseModel>> GetByRecipeIdAsync(int recipeId);

        Task DeteleAsync(int id);

        Task DeleteByRecipeIdAsync(int recipeId);

        Task<PhotoResponseModel> CreateAsync(CreatePhotoRequestModel request);
    }
}

