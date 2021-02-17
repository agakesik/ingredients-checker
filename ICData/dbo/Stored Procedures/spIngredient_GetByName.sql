CREATE PROCEDURE [dbo].[spIngredient_GetByName]
	@Name nvarchar(50)
AS
begin
	set nocount on;

	select [Id], [Name], [Details], [IngredientTypeId], [IsItCg]
	from dbo.Ingredient
	where [Name] = @Name;
end
