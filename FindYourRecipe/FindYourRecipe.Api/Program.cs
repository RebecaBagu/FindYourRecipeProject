using FindYourRecipe.DataAccess;
using FindYourRecipe.DataAccess.Interfaces;
using FindYourRecipe.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IRecipeDataContext, RecipeDataContext>();
builder.Services.AddScoped<IIngredientDataContext, IngredientDataContext>();
builder.Services.AddScoped<IPhotoDataContext, PhotoDataContext>();
builder.Services.AddScoped<ICategoryDataContext, CategoryDataContext>();
builder.Services.AddScoped<ICategoryRecipeDataContext, CategoryRecipeDataContext>();
builder.Services.AddScoped<IIngredientRecipeDataContext, IngredientRecipeDataContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

