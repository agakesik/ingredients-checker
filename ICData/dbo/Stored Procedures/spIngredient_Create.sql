CREATE PROCEDURE [dbo].[spIngredient_Create]
	@MainNameId int,
	@Details nvarchar(256) = NULL,
	@IngredientTypeId int = NULL,
	@IsItCg bit,
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Ingredient(MainNameId, Details, IngredientTypeId, IsItCg)
	values (@MainNameId, @Details, @IngredientTypeId, @IsItCg)

	set @Id = SCOPE_IDENTITY();
end
