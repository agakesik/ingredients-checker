using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class SqlIngredientTypeData : IIngredientTypeData
    {
        public Task<List<DBIngredientTypeModel>> GetAll(IDataAccess dataAccess)
        {
            var ingredientTypesList = dataAccess.LoadData<DBIngredientTypeModel, dynamic>("spIngredientType_GetAll", new { }, "ICData");

            return ingredientTypesList;
        }
    }
}
