using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICDataManager.Library.Helpers
{
    public class DisplayHelper : IDisplayHelper
    {
        public List<DisplayIngredientModel> GetIngrediensListForDisplay(List<DBIngredientModel> ingredientsList, List<DBIngredientTypeModel> typesList)
        {
            List<DisplayIngredientModel> detailedIngredientsList = MapIngredientForDisplayModel(ingredientsList);

            AddIngredienTypeDetails(detailedIngredientsList, typesList);

            return detailedIngredientsList;
        }

        private List<DisplayIngredientModel> MapIngredientForDisplayModel(List<DBIngredientModel> ingredientsList)
        {
            List<DisplayIngredientModel> detailedIngredientsList = new List<DisplayIngredientModel>();

            foreach (var ingredient in ingredientsList)
            {
                var detailedIngredient = new DisplayIngredientModel
                {
                    Name = ingredient.Name,
                    Details = ingredient.Details,
                    IngredientType = new DisplayIngredientTypeModel
                    {
                        Id = ingredient.IngredientTypeId
                    },
                    IsItCG = ingredient.IsItCG
                };

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
    }
}
