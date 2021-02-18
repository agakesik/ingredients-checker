CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MainNameId] INT NOT NULL, 
    [Details] NVARCHAR(256) NULL, 
    [IngredientTypeId] INT NULL, 
    [IsItCg] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Ingredient_ToIngredientType] FOREIGN KEY ([IngredientTypeId]) REFERENCES IngredientType(Id), 
    CONSTRAINT [FK_Ingredient_ToIngredientName] FOREIGN KEY ([MainNameId]) REFERENCES IngredientName(Id)
)
