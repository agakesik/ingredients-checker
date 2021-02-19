CREATE PROCEDURE [dbo].[spIngredient_GetById]
	@Id int
AS
begin
	set nocount on;

	select [Id], [MainNameId], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient
	where Id = @Id;
end
