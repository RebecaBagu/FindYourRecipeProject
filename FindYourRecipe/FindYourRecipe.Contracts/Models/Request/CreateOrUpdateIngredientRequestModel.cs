﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FindYourRecipe.Contracts.Models
{
    public class CreateOrUpdateIngredientRequestModel
    {
        [Required] public string Name { get; set; }
        [Required] public string Category { get; set; }
        
    }
}

