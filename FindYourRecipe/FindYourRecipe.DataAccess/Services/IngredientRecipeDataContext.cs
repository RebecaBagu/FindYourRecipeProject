using System;
using FindYourRecipe.DataAccess.Interfaces;

namespace FindYourRecipe.DataAccess.Services
{
	public class IngredientRecipeDataContext :IIngredientRecipeDataContext
	{
        public DataContext Database { get; }
		public IngredientRecipeDataContext(DataContext database)
		{
            Database = database;
		}

        public IngredientRecipe Create(int ingredientId, int recipeId, string quantity)
        {
            IngredientRecipe ingredientRecipe = new IngredientRecipe()
            {
                IngredientId = ingredientId,
                RecipeId = recipeId,
                Quantity = quantity,
            };
            Database.Add(ingredientRecipe);
            Database.SaveChanges();
            return ingredientRecipe;
        }

        public void Delete(int id)
        {
            Database.Remove(Database.IngredientsRecipes.First(x => x.Id == id));
        }

        public IngredientRecipe GetById(int id)
        {
            return Database.IngredientsRecipes.First(x => x.Id == id);
        }

        public IngredientRecipe Update(int id, int ingredientId, int recipeId, string quantity)
        {
            IngredientRecipe toUpdate = GetById(id);
            toUpdate.IngredientId = ingredientId;
            toUpdate.RecipeId = recipeId;
            toUpdate.Quantity = quantity;
            Database.SaveChanges();
            return toUpdate;
        }

        public bool Exists(int id)
        {
            if (Database.IngredientsRecipes.Any(p => p.Id == id))
            {
                return true;
            }
            else
                return false;
        }
    }
}

