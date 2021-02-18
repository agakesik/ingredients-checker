CREATE PROCEDURE [dbo].[spIngredient_GetByName]
	@MainNameID int
AS
begin
	set nocount on;

	select [Id], [MainNameId], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient
	where MainNameID = @MainNameID;
end
