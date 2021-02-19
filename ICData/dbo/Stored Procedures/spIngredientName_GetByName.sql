CREATE PROCEDURE [dbo].[spIngredientName_GetByName]
	@Name nvarchar(50)
AS
begin
	set nocount on;
	
	select [Id], [Name], [IngredientId]
	from dbo.IngredientName
	where [Name] = @Name;
end
