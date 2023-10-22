using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FindYourRecipe.Web;
using FindYourRecipe.Contracts;
using FindYourRecipe.Web.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7254/") });
builder.Services.AddTransient<IIngredientService, IngredientService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IIngredientRecipeService, IngredientRecipeService>();
builder.Services.AddTransient<ICategoryRecipeService, CategoryRecipeService>();
builder.Services.AddTransient<IPhotoService, PhotoService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();

