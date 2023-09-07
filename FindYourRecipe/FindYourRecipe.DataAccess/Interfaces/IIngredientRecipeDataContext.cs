using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IIngredientRecipeDataContext
	{
		public IngredientRecipe GetById(int id);

		public IngredientRecipe Create(int ingredientId, int recipeId, string quantity);

		public IngredientRecipe Update(int id,int ingredientId, int recipeId, string quantity)

		public void Delete(int id);
	}
}

