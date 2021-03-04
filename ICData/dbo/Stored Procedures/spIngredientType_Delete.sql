CREATE PROCEDURE [dbo].[spIngredientType_Delete]
	@Id int
AS
begin
	set nocount on;

	delete 
	from dbo.IngredientType
	where Id = @Id;
end
