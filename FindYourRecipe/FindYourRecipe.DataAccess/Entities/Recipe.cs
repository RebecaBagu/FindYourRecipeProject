using System;
namespace FindYourRecipe.DataAccess
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Cuisine { get; set; }
		public string Dificulty { get; set; }
		public string RecipeLink { get; set; }

		public ICollection<Photo> Photos { get; set; }

        public IList<IngredientRecipe> IngredientRecipes { get; set; }

		public IList<CategoryRecipe> CategoryRecipe { get; set; }

		
    }
}

