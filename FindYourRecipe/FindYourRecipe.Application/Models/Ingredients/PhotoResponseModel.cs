using System;
namespace FindYourRecipe.Application.Models.Ingredients
{
	public class PhotoResponseModel
	{
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Link { get; set; }
    }
}

