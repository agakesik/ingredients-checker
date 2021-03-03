CREATE PROCEDURE [dbo].[spIngredientName_Update]
    @Id int,
    @Name nvarchar(50),
    @IngredientId int = null
AS
begin
    
    set nocount on;

    update dbo.IngredientName
    set [Name] = @Name, IngredientId = @IngredientId
    where Id = @Id;
end