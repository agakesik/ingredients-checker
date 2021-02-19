using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
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
    }
}
