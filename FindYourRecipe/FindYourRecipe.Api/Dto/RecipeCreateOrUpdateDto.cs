using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Api.Dto
{
	public class RecipeCreateOrUpdateDto
	{
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Cuisine { get; set; }
        [Required] public string Dificulty { get; set; }
        [Required] public string RecipeLink { get; set; }

    }
}

