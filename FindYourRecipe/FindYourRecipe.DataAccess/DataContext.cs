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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientRecipe>().HasKey(sc => new { sc.RecipeId, sc.IngredientId });
            modelBuilder.Entity<CategoryRecipe>().HasKey(sc => new { sc.RecipeId, sc.CategoryId });

			modelBuilder.Entity<Photo>()
				.HasOne<Recipe>(r => r.Recipe)
				.WithMany(p => p.Photos)
				.HasForeignKey(r => r.RecipeId);
        }

       

        public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
    }
}

