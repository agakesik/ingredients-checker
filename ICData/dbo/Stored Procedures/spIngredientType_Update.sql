CREATE PROCEDURE [dbo].[spIngredientType_Update]
	@Id int,
	@Name nvarchar(50),
	@Details nvarchar(256) = NULL,
	@Color nvarchar(10)
AS
begin
	set nocount on;

	update dbo.IngredientType
	set  [Name] = @Name, Details = @Details, Color = @Color
	where Id = @Id;
end
