using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Application.Models
{
	public class CreateOrUpdateRecipeRequestModel
	{
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Cuisine { get; set; }
        [Required] public string Dificulty { get; set; }
        [Required] public string RecipeLink { get; set; }

    }
}

