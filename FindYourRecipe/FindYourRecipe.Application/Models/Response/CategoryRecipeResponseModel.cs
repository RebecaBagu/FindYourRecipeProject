using System;
namespace FindYourRecipe.Application.Models.Response
{
	public class CategoryRecipeResponseModel
	{
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }
    }
}

