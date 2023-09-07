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
	}
}

