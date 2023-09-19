using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Application.Models.Ingredients
{
	public class CreatePhotoRequestModel
	{
        [Required] public int RecipeId { get; set; }
        [Required] public string Link { get; set; }
    }
}

