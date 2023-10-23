
CREATE DATABASE FindYourRecipe;
CREATE TABLE Recipes 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(50),
    Instructions VARCHAR(MAX),
    Category VARCHAR(30),
    Dificulty VARCHAR(30)
);

CREATE TABLE Ingredients 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Category VARCHAR(30)
);

CREATE TABLE Photos 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT REFERENCES Recipes(Id), 
    Link VARCHAR(100)
);

CREATE TABLE IngredientsRecipes 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT REFERENCES Recipes(Id), 
    IngredientId INT REFERENCES Ingredients(Id), 
    Quantity VARCHAR(20)
);

CREATE TABLE Users 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(30),
    Email VARCHAR(30),
    Password VARCHAR(30)
);

CREATE TABLE Reviews 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT REFERENCES Recipes(Id), 
    UserId INT REFERENCES Users(Id),
    Text VARCHAR(MAX),
    Stars INT CHECK(Stars >0 AND Stars<6)
);