using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IPhotoRepository
	{
		Task<Photo> GetByIdAsync(int id);

		Task<List<Photo>> GetByRecipeIdAsync(int recipeId);

		Task DeteleAsync(int id);

		Task<Photo> CreateAsync(int recipeId, string link);

        Task<bool> ExistsAsync(int id);

        Task DeleteByRecipeIdAsync(int recipeId);
    }
}

