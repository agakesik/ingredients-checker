CREATE PROCEDURE [dbo].[spIngredientType_GetById]
	@Id int
AS
begin
	set nocount on;

	select [Id], [Name], [Details], [Color]
	from dbo.IngredientType
	where Id = @Id
end