using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Application.Models
{
	public class CreateIngredientRecipeRequestModel
	{
        [Required] public int IngredientId { get; set; }
        [Required] public int RecipeId { get; set; }
        [Required] public string Quantity { get; set; }

    }
}

