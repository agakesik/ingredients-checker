CREATE PROCEDURE [dbo].[spIngredient_GetAll]
AS
begin
	set nocount on;

	select [Id], [name], [details], [ingredientTypeId], [isItCg]
	from dbo.Ingredient

end
