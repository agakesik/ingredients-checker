using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class IngredientTypeData
    {
        public Task<List<IngredientTypeModel>> GetAll(IDataAccess dataAccess)
        {
            var ingredientTypesList = dataAccess.LoadData<IngredientTypeModel, dynamic>("spIngredientType_GetAll", new { }, "ICData");

            return ingredientTypesList;
        }
    }
}
