CREATE PROCEDURE [dbo].[spIngredientName_Create]
	@Name nvarchar(50),
	@IngredientId int = null,
	@Id int output
AS
begin
	
	set nocount on;

	insert into dbo.IngredientName([Name], IngredientId)
	values (@Name, @IngredientId)

	set @Id = SCOPE_IDENTITY();
end

