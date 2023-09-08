using System;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.DataAccess.Services
{
	public class PhotoDataContext : IPhotoDataContext
	{
		public DataContext Database { get; }
		public PhotoDataContext(DataContext database)
		{
			Database = database;
		}

        public Photo GetById(int id)
        {
            return Database.Photos.First(x => x.Id == id);
        }

        public void Detele(int id)
        {
            Database.Remove(Database.Photos.First(x => x.Id == id));
        }

        public List<Photo> GetByRecipeId(int recipeId)
        {
            return Database.Photos.Where(x => x.RecipeId == recipeId).ToList();
        }

        public Photo Create(int recipeId, string link)
        {
            Photo photo = new Photo()
            {
                RecipeId = recipeId,
                Link = link,
            };
            Database.Add(photo);
            Database.SaveChanges();
            return photo;
        }

        public bool Exists(int id)
        {
            if (Database.Photos.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

