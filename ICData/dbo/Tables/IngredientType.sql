CREATE TABLE [dbo].[IngredientType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Details] NVARCHAR(256) NULL, 
    [Color] NVARCHAR(10) NULL
)
