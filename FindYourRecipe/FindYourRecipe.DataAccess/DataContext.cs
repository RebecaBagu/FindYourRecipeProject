using FindYourRecipe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindYourRecipe.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryRecipe> CategoryRecipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientRecipe> IngredientsRecipes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<IngredientRecipe>()
                .HasKey(sc => new { sc.RecipeId, sc.IngredientId });

            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(sc => new { sc.RecipeId, sc.CategoryId });

            modelBuilder.Entity<Photo>()
                .HasOne<Recipe>(r => r.Recipe)
                .WithMany(p => p.Photos)
                .HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<Recipe>()
                .HasMany<IngredientRecipe>(ir => ir.IngredientRecipes)
                .WithOne(r => r.Recipe)
                .HasForeignKey(ir => ir.RecipeId);

            modelBuilder.Entity<Recipe>()
                .HasMany<CategoryRecipe>(cr => cr.CategoryRecipes)
                .WithOne(r => r.Recipe)
                .HasForeignKey(cr => cr.RecipeId);

            modelBuilder.Entity<Ingredient>()
                .HasMany<IngredientRecipe>(ir => ir.IngredientRecipes)
                .WithOne(i => i.Ingredient)
                .HasForeignKey(ir => ir.IngredientId);

            modelBuilder.Entity<IngredientRecipe>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Role>()
              .HasMany<User>(u => u.Users)
              .WithOne(r => r.Role)
              .HasForeignKey(u => u.RoleId);

        }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}

