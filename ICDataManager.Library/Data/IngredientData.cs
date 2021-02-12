using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class IngredientData
    {
        public Task<List<DBIngredientModel>> GetAll(IDataAccess dataAccess)
        {
            var ingredientsList = dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetAll", new { }, "ICData");

            return ingredientsList;

        }
    }
}
