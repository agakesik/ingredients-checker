CREATE TABLE [dbo].[IngredientName]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [IngredientId] INT NULL, 
    CONSTRAINT [FK_IngredientName_ToIngredient] FOREIGN KEY (IngredientId) REFERENCES Ingredient(Id)
)
