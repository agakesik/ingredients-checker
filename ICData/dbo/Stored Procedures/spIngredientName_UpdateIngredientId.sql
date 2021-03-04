CREATE PROCEDURE [dbo].[spIngredientName_UpdateIngredientId]
    @Id int,
    @IngredientId int = NULL
AS
begin
    
    set nocount on;

    update dbo.IngredientName
    set IngredientId = @IngredientId
    where Id = @Id;
end
