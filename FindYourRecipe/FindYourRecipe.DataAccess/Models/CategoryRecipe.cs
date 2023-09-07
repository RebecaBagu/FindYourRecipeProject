using System;
namespace FindYourRecipe.DataAccess
{
	public class CategoryRecipe
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int RecipeId { get; set; }
	}
}

