CREATE PROCEDURE [dbo].[spIngredientName_GetByIngredient]
	@IngredientId int
AS
begin
	set nocount on;

	Select [Id], [Name], [IngredientId]
	from dbo.IngredientName
	where IngredientId = @IngredientId
end