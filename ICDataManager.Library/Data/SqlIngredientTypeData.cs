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
        private readonly IDataAccess _dataAccess;

        public SqlIngredientTypeData(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<List<DBIngredientTypeModel>> GetAll()
        {
            var ingredientTypesList = _dataAccess.LoadData<DBIngredientTypeModel, dynamic>("spIngredientType_GetAll", new { }, "ICData");

            return ingredientTypesList;
        }

        public async Task<int> Delete(int id)
        {
            return await _dataAccess.SaveData("spIngredientType_Delete", new { Id = id }, "ICData");
        }
    }
}
