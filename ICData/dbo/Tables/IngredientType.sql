CREATE TABLE [dbo].[IngredientType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(50) NOT NULL, 
    [details] NCHAR(256) NULL, 
    [color] NCHAR(10) NULL
)
