CREATE PROCEDURE [dbo].[spIngredientName_GetById]
	@Id int
AS
begin
	set nocount on;
	
	select [Id], [Name], [IngredientId]
	from dbo.IngredientName
	where Id = @Id;
end