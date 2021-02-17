CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Details] NTEXT NULL, 
    [IngredientTypeId] INT NULL, 
    [IsItCg] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Ingredient_ToIngredientType] FOREIGN KEY ([IngredientTypeId]) REFERENCES IngredientType(Id)
)
