using System;
namespace FindYourRecipe.Application.Models.Response
{
	public class IngredientRecipeResponseModel
	{
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Quantity { get; set; }
    }
}

