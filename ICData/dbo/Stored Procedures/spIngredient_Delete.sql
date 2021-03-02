CREATE PROCEDURE [dbo].[spIngredient_Delete]
	@Id int
AS
begin
	set nocount on;

	delete 
	from dbo.Ingredient
	where Id = @Id;
end