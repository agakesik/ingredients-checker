CREATE PROCEDURE [dbo].[spIngredientType_Create]
	@Name nvarchar(50),
	@Details nvarchar(256) = NULL,
	@Color nvarchar(10),
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.IngredientType([Name], Details, Color)
	values (@Name, @Details, @Color)

	set @Id = SCOPE_IDENTITY();
end