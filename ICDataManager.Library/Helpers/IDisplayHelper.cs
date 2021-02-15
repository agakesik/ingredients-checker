using ICDataManager.Library.Models;
using System.Collections.Generic;

namespace ICDataManager.Library.Helpers
{
    public interface IDisplayHelper
    {
        List<DisplayIngredientModel> GetIngrediensListForDisplay(List<DBIngredientModel> ingredientsList, List<DBIngredientTypeModel> typesList);
    }
}