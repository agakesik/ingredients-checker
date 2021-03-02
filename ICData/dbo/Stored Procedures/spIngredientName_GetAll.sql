CREATE PROCEDURE [dbo].[spIngredientName_GetAll]
AS
begin
	set nocount on;

	select [Id], [Name], [IngredientId]
	from dbo.IngredientName

end