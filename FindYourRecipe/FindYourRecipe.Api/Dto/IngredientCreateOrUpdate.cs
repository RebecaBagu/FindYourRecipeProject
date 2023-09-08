using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Api.Dto
{
	public class IngredientCreateOrUpdate
	{

        [Required] public string Name { get; set; }
        [Required] public string Category { get; set; }
    }
}

