CREATE PROCEDURE [dbo].[spIngredient_UpdateTypeId]
	@Id int,
	@IngredientTypeId int = null
AS
begin
	set nocount on;

	update dbo.Ingredient
	set IngredientTypeId = @IngredientTypeId
	where Id = @Id
end