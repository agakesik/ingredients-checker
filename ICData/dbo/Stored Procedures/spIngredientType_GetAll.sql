CREATE PROCEDURE [dbo].[spIngredientType_GetAll]
AS
begin
	set nocount on;

	select [Id], [name], [details], [color]
	from dbo.IngredientType
end