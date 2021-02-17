CREATE PROCEDURE [dbo].[spIngredient_GetAll]
AS
begin
	set nocount on;

	select [Id], [Name], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient

end
