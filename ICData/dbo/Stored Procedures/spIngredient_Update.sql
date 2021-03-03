CREATE PROCEDURE [dbo].[spIngredient_Update]
	@Id int,
	@MainNameId int,
	@Details nvarchar(256),
	@IngredientTypeId int = NULL,
	@IsItCG bit
AS
begin
	set nocount on;

	update dbo.Ingredient
	set  MainNameId = @MainNameId, Details = @Details, IngredientTypeId = @IngredientTypeId, IsItCg = @IsItCG
	where Id = @Id;
end
