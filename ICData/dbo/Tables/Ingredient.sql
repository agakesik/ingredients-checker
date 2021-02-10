CREATE TABLE [dbo].[Ingredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[name] NVARCHAR(50) NOT NULL, 
	[details] NCHAR(256) NULL, 
	[ingredientTypeId] INT NOT NULL, 
	[isItCG] BIT NOT NULL DEFAULT 0, 
	CONSTRAINT [FK_Ingredients_ToIngredientType] FOREIGN KEY (ingredientTypeId) REFERENCES IngredientType(Id)
)
