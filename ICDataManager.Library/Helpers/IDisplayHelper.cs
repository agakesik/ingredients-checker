using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Helpers
{
    public interface IDisplayHelper
    {
        Task<List<DisplayIngredientModel>> GetIngrediensListForDisplay(List<DBIngredientModel> ingredientsList, List<DBIngredientTypeModel> typesList);
    }
}