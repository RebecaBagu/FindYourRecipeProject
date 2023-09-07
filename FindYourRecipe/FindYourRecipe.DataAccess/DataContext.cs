using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess
{
	public class DataContext : DbContext
	{
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<CategoryRecipe> CategoryRecipes { get; set;}
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<IngredientRecipe> IngredientsRecipes { get; set; }
		public DbSet<Photo> Photos { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
    }
}

