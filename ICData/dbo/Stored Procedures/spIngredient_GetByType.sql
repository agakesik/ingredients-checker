CREATE PROCEDURE [dbo].[spIngredient_GetByType]
	@IngredientTypeId int
AS
begin
	set nocount on;

	select [Id], [MainNameId], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient
	where IngredientTypeId = @IngredientTypeId;
end