namespace FindYourRecipe.DataAccess;

public class Photo
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string Link { get; set; }

    public Recipe Recipe { get; set; }

}

