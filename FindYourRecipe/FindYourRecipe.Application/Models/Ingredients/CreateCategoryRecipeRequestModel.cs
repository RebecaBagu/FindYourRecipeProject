using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Application.Models.Ingredients
{
	public class CreateCategoryRecipeRequestModel
	{
        [Required] public int CategoryId { get; set; }
        [Required] public int RecipeId { get; set; }
    }
}

