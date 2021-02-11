CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL, 
    [details] NCHAR(256) NULL, 
    [ingredientTypeId] INT NOT NULL, 
    [isItCg] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Ingredient_ToIngredientType] FOREIGN KEY (ingredientTypeId) REFERENCES IngredientType(Id)
)
