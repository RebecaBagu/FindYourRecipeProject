using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IPhotoDataContext
	{
		public Photo GetById(int id);

		public List<Photo> GetByRecipeId(int recipeId);

		public void Detele(int id);

		public Photo Create(int recipeId, string link);

        public bool Exists(int id);
    }
}

