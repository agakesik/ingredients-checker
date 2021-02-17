CREATE TABLE [dbo].[IngredientType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NOT NULL, 
    [Details] NCHAR(256) NULL, 
    [Color] NCHAR(10) NULL
)
