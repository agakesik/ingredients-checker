CREATE TABLE [dbo].[IngredientType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NCHAR(50) NOT NULL, 
    [details] NCHAR(256) NULL, 
    [color] NCHAR(10) NULL
)
