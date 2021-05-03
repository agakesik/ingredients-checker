CREATE PROCEDURE [dbo].[spIngredientType_GetAll]
AS
begin
	set nocount on;

	select [Id], [Name], [Details], [Color]
	from dbo.IngredientType
end