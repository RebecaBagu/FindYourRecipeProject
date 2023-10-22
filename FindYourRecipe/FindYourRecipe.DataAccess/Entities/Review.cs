﻿using System;
namespace FindYourRecipe.DataAccess.Entities
{
	public class Review
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Stars { get; set; }
		public int UserId { get; set; }
		public int RecipeId { get; set; }

		public Recipe Recipe { get; set; }

		public User User { get; set; }
	}
}

