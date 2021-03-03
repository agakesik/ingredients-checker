using Dapper;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class SqlIngredientNameData : IIngredientNameData
    {
        private readonly IDataAccess _dataAccess;

        public SqlIngredientNameData(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<DBIngredientNameModel>> GetAll()
        {
            var ingredientNamesList = _dataAccess.LoadData<DBIngredientNameModel, dynamic>("spIngredientName_GetAll", new { }, "ICData");

            return ingredientNamesList;

        }

        public async Task<DBIngredientNameModel> GetById(int id)
        {
            var ingredientName = await _dataAccess.LoadData<DBIngredientNameModel, dynamic>("spIngredientName_GetById", new { Id = id }, "ICData");

            return ingredientName.FirstOrDefault();
        }

        public async Task<DBIngredientNameModel> GetByName(string name)
        {
            var ingredientName = await _dataAccess.LoadData<DBIngredientNameModel, dynamic>("spIngredientName_GetByName", new { Name = name }, "ICData");

            return ingredientName.FirstOrDefault();
        }

        public async Task<int> SaveName(string name)
        {
            DynamicParameters nameObject = new DynamicParameters();
            nameObject.Add("Name", name);
            nameObject.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("spIngredientName_AddName", nameObject, "ICData");

            return nameObject.Get<int>("Id");
        }

        public async Task<int> Update(ManageIngredientNamesModel editedInformation)
        {

            DynamicParameters p = new DynamicParameters();
            p.Add("Id", editedInformation.Id);
            p.Add("Name", editedInformation.Name);

            if (editedInformation.IngredientId > 0)
            {
                p.Add("IngredientId", editedInformation.IngredientId);
            }
            return await _dataAccess.SaveData("spIngredientName_Update", p, "ICData");
        }

        public async Task<int> DeleteName(int id)
        {
            return await _dataAccess.SaveData("spIngredientName_Delete", new { Id = id }, "ICData");
        }


    }
}
