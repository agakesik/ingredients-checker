using Dapper;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<int> Create(DBIngredientTypeModel ingredientType)
        {
            DynamicParameters typeParameter = new DynamicParameters();
            typeParameter.Add("Name", ingredientType.Name);
            typeParameter.Add("Details", ingredientType.Details);
            typeParameter.Add("Color", ingredientType.Color);
            typeParameter.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("spIngredientType_Create", typeParameter, "ICData");

            return typeParameter.Get<int>("Id");
        }

        public async Task<int> Delete(int id)
        {
            return await _dataAccess.SaveData("spIngredientType_Delete", new { Id = id }, "ICData");
        }
    }
}
