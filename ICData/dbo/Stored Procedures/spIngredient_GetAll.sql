CREATE PROCEDURE [dbo].[spIngredient_GetAll]
AS
begin
	set nocount on;

	select [Id], [MainNameId], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient

end
