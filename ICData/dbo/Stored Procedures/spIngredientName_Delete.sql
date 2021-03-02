CREATE PROCEDURE [dbo].[spIngredientName_Delete]
	@Id int
AS
begin
	set nocount on;

	delete 
	from dbo.IngredientName
	where Id = @Id;
end