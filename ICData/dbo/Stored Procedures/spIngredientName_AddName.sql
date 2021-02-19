CREATE PROCEDURE [dbo].[spIngredientName_AddName]
	@Name nvarchar(50),
	@Id int output
AS
begin
    
    set nocount on;

    insert into dbo.IngredientName([Name])
    values (@Name)

    set @Id = SCOPE_IDENTITY();
end

