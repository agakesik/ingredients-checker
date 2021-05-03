using ICDataManager.Library.Data;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Helpers
{

    public class DisplayHelper : IDisplayHelper
    {
        private readonly IIngredientNameData _ingredientNameData;

        public DisplayHelper(IIngredientNameData ingredientNameData)
        {
            _ingredientNameData = ingredientNameData;
        }

        public async Task<List<DisplayIngredientModel>> GetIngrediensListForDisplay(List<DBIngredientModel> ingredientsList, List<DBIngredientTypeModel> typesList)
        {
            List<DisplayIngredientModel> detailedIngredientsList = await MapIngredientForDisplayModel(ingredientsList);

            AddIngredienTypeDetails(detailedIngredientsList, typesList);

            return detailedIngredientsList;
        }

        private async Task<List<DisplayIngredientModel>> MapIngredientForDisplayModel(List<DBIngredientModel> ingredientsList)
        {
            List<DisplayIngredientModel> detailedIngredientsList = new List<DisplayIngredientModel>();

            foreach (var ingredient in ingredientsList)
            {
                var detailedIngredient = new DisplayIngredientModel
                {
                    Details = ingredient.Details,
                    IngredientType = new DisplayIngredientTypeModel
                    {
                        Id = ingredient.IngredientTypeId
                    },
                    IsItCG = ingredient.IsItCG
                };

                 await AddIngredientName(detailedIngredient, ingredient.MainNameId);
                detailedIngredientsList.Add(detailedIngredient);
            }

            return detailedIngredientsList;
        }

        private void AddIngredienTypeDetails(List<DisplayIngredientModel> detailedIngredientList, List<DBIngredientTypeModel> typesList)
        {
            foreach (var ingredient in detailedIngredientList)
            {
                if (ingredient.IngredientType.Id == 0)
                {
                    continue;
                }

                var type = FindIngredientTypeByID(ingredient.IngredientType.Id, typesList);
                if (type == null)
                {
                    continue;
                }

                ingredient.IngredientType.Name = type.Name;
                ingredient.IngredientType.Details = type.Details;
                ingredient.IngredientType.Color = type.Color;
            }
        }

        private DBIngredientTypeModel FindIngredientTypeByID(int id, List<DBIngredientTypeModel> typesList)
        {
            return typesList.Where(type => type.Id == id).FirstOrDefault();
        }

        private async Task AddIngredientName(DisplayIngredientModel detailedIngredientList, int id)
        {
            var nameInformation = await _ingredientNameData.GetById(id);
            detailedIngredientList.Name = nameInformation.Name;
        }
    }
}
