using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Contracts.Models
{
	public class CreatePhotoRequestModel
	{
        [Required] public int RecipeId { get; set; }
        [Required] public string Link { get; set; }
    }
}

