using System;
namespace FindYourRecipe.Application.Models.Ingredients
{
	public class RecipeResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Dificulty { get; set; }
        public string RecipeLink { get; set; }
    }
}

