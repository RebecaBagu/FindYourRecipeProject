using System;
using FindYourRecipe.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess.Repositories
{
	public class PhotoRepository : IPhotoRepository
	{
		public DataContext Database { get; }
		public PhotoRepository(DataContext database)
		{
			Database = database;
		}

        public Task<Photo> GetByIdAsync(int id)
        {
            return Database.Photos.FirstAsync(x => x.Id == id);
        }

        public async Task DeteleAsync(int id)
        {
            Database.Remove(await Database.Photos.FirstAsync(x => x.Id == id));
            await Database.SaveChangesAsync();
        }

        public  Task<List<Photo>> GetByRecipeIdAsync(int recipeId)
        {
            return Database.Photos.Where(x => x.RecipeId == recipeId).ToListAsync();
        }

        public async Task<Photo>  CreateAsync(int recipeId, string link)
        {
            Photo photo = new Photo()
            {
                RecipeId = recipeId,
                Link = link,
            };
            Database.Add(photo);
            await Database.SaveChangesAsync();
            return photo;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            if (await Database.Photos.AnyAsync(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }

        public async Task DeleteByRecipeIdAsync(int recipeId)
        {
            var photos = await (from photo in Database.Photos
                         where (photo.RecipeId == recipeId)
                         select photo).ToListAsync();
            Database.RemoveRange(photos);
            await Database.SaveChangesAsync();
        }
    }
}

