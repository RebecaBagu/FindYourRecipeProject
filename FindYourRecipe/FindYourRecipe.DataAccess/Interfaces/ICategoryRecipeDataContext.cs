using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface ICategoryRecipeDataContext
	{
		public CategoryRecipe GetById(int id);
		public CategoryRecipe Create(int categoryId, int recipeId);
		public CategoryRecipe Update(int id, int categoryId, int recipeId);
		public void Delete(int Id);
	}
}

